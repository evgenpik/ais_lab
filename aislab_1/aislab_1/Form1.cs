using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogical;
using Model;
using System.Configuration;
using DataAccessLayer;


namespace aislab_1
{
    public partial class MainForm : Form
    {
        private readonly Logic logic;
        private DataGridViewRow selectedRow = null; //выборная ячейка таблицы
        private BindingSource gamesBinding = new BindingSource(); //прослойка чтобы спокойно работать с таблицей
        private List<Game> allGames;
        private List<Platform> _cachedPlatforms;

        public MainForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cachedPlatforms = logic.GetAllPlatforms();
            SetupInputControls();
            SetupDataGridView();
            UpdateGamesGrid();
            comboBox_Genre.DataSource = Enum.GetValues(typeof(Genre));
        }
        #region Вспомогательные методы
        /// <summary>
        /// Метод, задающий поля для ввода данных
        /// </summary>
        private void SetupInputControls()
        {
            comboBox_Genre.DataSource = Enum.GetValues(typeof(Genre));
            comboBox_Platform.DataSource = _cachedPlatforms;
            comboBox_Platform.DisplayMember = "Name";    // Показываем название
            comboBox_Platform.ValueMember = "Id";        // Используем ID
            comboBox_Platform.SelectedIndex = -1;

            numericUpDown_Rating.Minimum = 1;
            numericUpDown_Rating.Maximum = 10;
            numericUpDown_ReleaseYear.Minimum = 1970;
            numericUpDown_ReleaseYear.Maximum = DateTime.Now.Year;
            numericUpDown_ReleaseYear.Value = DateTime.Now.Year;
        }

        /// <summary>
        /// Метод, задающий поля таблицы DatagridView
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Название", DataPropertyName = "Title" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Разработчик", DataPropertyName = "Developer" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Жанр", DataPropertyName = "Genre" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Платформа", DataPropertyName = "Platform" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Рейтинг", DataPropertyName = "Rating" });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = gamesBinding;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        /// <summary>
        /// Метод, обновляющий поля таблицы
        /// </summary>
            private void UpdateGamesGrid()
            {
                allGames = logic.GetAllGames();
                var displayGames = allGames.Select(g => new  // ✅ ПРЕОБРАЗУЕМ в анонимный тип
                {
                    g.Title,
                    g.Developer,
                    Genre = g.GameGenre.ToString(),
                    Platform = _cachedPlatforms.FirstOrDefault(p => p.Id == g.PlatformId)?.Name ?? "—",
                    g.ReleaseYear,
                    g.Rating
                }).ToList();

                gamesBinding.DataSource = displayGames;
                dataGridView1.DataSource = gamesBinding;

                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.ClearSelection();
            }


            


        /// <summary>
        /// Метод, сбрасывающий поля ввода
        /// </summary>
        private void ClearInputFields()
        {
            textBox_Title.Clear();
            textBox_Developer.Clear();
            comboBox_Genre.SelectedIndex = 0;
            comboBox_Platform.SelectedIndex = 0;
            numericUpDown_ReleaseYear.Value = DateTime.Now.Year;
            numericUpDown_Rating.Value = 1;
            dataGridView1.ClearSelection();
            selectedRow = null;
        }
        #endregion

        #region Обработчики событий
        /// <summary>
        /// Обработчик кноппки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            string title = textBox_Title.Text;
            string developer = textBox_Developer.Text;
            Genre genre = (Genre)comboBox_Genre.SelectedItem;
            Guid platformId = (Guid)comboBox_Platform.SelectedValue;  
            int year = (int)numericUpDown_ReleaseYear.Value;
            int rating = (int)numericUpDown_Rating.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(developer))
            {
                MessageBox.Show("Название и Разработчик не могут быть пустыми!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            logic.AddGame(title, genre, developer, year, platformId, rating);
            UpdateGamesGrid();
            ClearInputFields();
        }
        /// <summary>
        /// Обработчик кнопки "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Change_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите игру для изменения.",
                                "Информация",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // ✅ Получаем Title из первого столбца и ищем игру в allGames
            var gameTitle = selectedRow.Cells[0].Value?.ToString();
            var gameToChange = allGames.FirstOrDefault(g => g.Title == gameTitle);

            if (gameToChange != null)
            {
                // Собираем новые значения из формы
                string newTitle = textBox_Title.Text;
                int newRating = (int)numericUpDown_Rating.Value;
                Guid newPlatformId = (Guid)comboBox_Platform.SelectedValue;
                string newDeveloper = textBox_Developer.Text;
                Genre newGenre = (Genre)comboBox_Genre.SelectedItem;

                logic.ChangeGame(gameToChange.Id, newTitle, newRating, newPlatformId, newDeveloper, newGenre);
                UpdateGamesGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Ошибка: игра не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите игру для удаления.",
                                "Информация",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // ✅ Получаем Title из таблицы и ищем эту игру в allGames
            var gameTitle = selectedRow.Cells[0].Value?.ToString();
            var gameToDelete = allGames.FirstOrDefault(g => g.Title == gameTitle);

            if (gameToDelete != null)
            {
                var confirmation = MessageBox.Show($"Вы уверены, что хотите удалить игру '{gameToDelete.Title}'?",
                                                  "Подтверждение удаления",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    logic.DeleteGame(gameToDelete.Id);
                    UpdateGamesGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Ошибка: игра не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обработчик кнопки "Фильтровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            if (comboBox_Platform.SelectedValue == null)
                return;

            var selectedPlatformId = (Guid)comboBox_Platform.SelectedValue;

            var filteredGames = allGames.Where(g => g.PlatformId == selectedPlatformId).ToList();

            var displayGames = filteredGames.Select(g => new
            {
                g.Title,
                g.Developer,
                Genre = g.GameGenre.ToString(),
                Platform = _cachedPlatforms.FirstOrDefault(p => p.Id == g.PlatformId)?.Name ?? "—",  
                g.ReleaseYear,
                g.Rating
            }).ToList();

            // Привязываем данные к таблице
            gamesBinding.DataSource = displayGames;
            dataGridView1.DataSource = gamesBinding;

            // Сбрасываем выделение
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();

            selectedRow = null;
        }
        /// <summary>
        /// Обработчик кнопки "Группировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Group_Click(object sender, EventArgs e)
        {
            var sortedGames = allGames.OrderBy(g => g.GameGenre).ThenBy(g => g.Title).ToList();

            // ✅ ДОБАВИТЬ: Преобразуем в анонимный тип (как в UpdateGamesGrid)
            var displayGames = sortedGames.Select(g => new
            {
                g.Title,
                g.Developer,
                Genre = g.GameGenre.ToString(),
                Platform = _cachedPlatforms.FirstOrDefault(p => p.Id == g.PlatformId)?.Name ?? "—",
                g.ReleaseYear,
                g.Rating
            }).ToList();

            gamesBinding.DataSource = displayGames;
            dataGridView1.DataSource = gamesBinding;
            dataGridView1.ClearSelection();
            selectedRow = null;
        }
        /// <summary>
        /// Обработчик "Сбросить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Reset_Click(object sender, EventArgs e)
        {
            UpdateGamesGrid();  
            ClearInputFields();

        }
        /// <summary>
        /// Метод для смены строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];

                // ✅ Получаем Title из первого столбца и ищем игру в allGames
                var gameTitle = selectedRow.Cells[0].Value?.ToString();
                var selectedGame = allGames.FirstOrDefault(g => g.Title == gameTitle);

                if (selectedGame != null)
                {
                    textBox_Title.Text = selectedGame.Title;
                    textBox_Developer.Text = selectedGame.Developer;
                    comboBox_Genre.SelectedItem = selectedGame.GameGenre;
                    comboBox_Platform.SelectedValue = selectedGame.PlatformId;
                    numericUpDown_ReleaseYear.Value = selectedGame.ReleaseYear;
                    numericUpDown_Rating.Value = selectedGame.Rating;
                }
            }
            else
            {
                selectedRow = null;
                ClearInputFields();
            }
        }

        #endregion

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateGamesGrid();
        }

       
    }
}


