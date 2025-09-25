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


namespace aislab_1
{
    public partial class MainForm : Form
    {
        private readonly Logic logic = new Logic();
        private DataGridViewRow selectedRow = null; //выборная ячейка таблицы
        private BindingSource gamesBinding = new BindingSource(); //прослойка чтобы спокойно работать с таблицей
        private List<Game> allGames;

        public MainForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            comboBox_Platform.DataSource = new string[] { "PC", "PlayStation 5", "Xbox Series X", "Nintendo Switch", "Other" };
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
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Жанр", DataPropertyName = "GameGenre" });
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
            allGames = logic.Games.ToList(); // сохраняем полный список
            gamesBinding.DataSource = allGames;
            dataGridView1.ClearSelection();
            selectedRow = null;
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
            string platform = comboBox_Platform.SelectedItem.ToString();
            int year = (int)numericUpDown_ReleaseYear.Value;
            int rating = (int)numericUpDown_Rating.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(developer))
            {
                MessageBox.Show("Название и Разработчик не могут быть пустыми!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            logic.AddGame(title, genre, developer, year, platform, rating);
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
            if (selectedRow != null)
            {
                Game selectedGame = selectedRow.DataBoundItem as Game;
                if (selectedGame != null)
                {
                    string newTitle = textBox_Title.Text;
                    int newRating = (int)numericUpDown_Rating.Value;
                    string newPlatform = comboBox_Platform.Text;
                    string newDeveloper = textBox_Developer.Text;
                    Genre newGenre = (Genre)comboBox_Genre.SelectedItem;
                    logic.ChangeGame(selectedGame.Id, newTitle, newRating, newPlatform, newDeveloper, newGenre);
                    UpdateGamesGrid();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите игру для изменения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                var confirmation = MessageBox.Show(
                    "Вы уверены, что хотите удалить эту игру?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    Game selectedGame = selectedRow.DataBoundItem as Game;
                    if (selectedGame != null)
                    {
                        logic.DeleteGame(selectedGame.Id);
                        UpdateGamesGrid();
                        ClearInputFields();
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Пожалуйста, выберите игру для удаления.",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Обработчик кнопки "Фильтровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            string platform = comboBox_Platform.SelectedItem.ToString();
            var filteredGames = allGames.Where(g => g.Platform == platform).ToList();

            gamesBinding.DataSource = filteredGames;
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

            // присваиваю биндингу новую отсортированную коллекцию
            gamesBinding.DataSource = sortedGames;

            // сбрасываю выделение
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
            gamesBinding.DataSource = allGames;
            dataGridView1.ClearSelection();
            selectedRow = null;
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
                Game selectedGame = selectedRow.DataBoundItem as Game;
                if (selectedGame != null)
                {
                    textBox_Title.Text = selectedGame.Title;
                    textBox_Developer.Text = selectedGame.Developer;
                    comboBox_Genre.SelectedItem = selectedGame.GameGenre;
                    comboBox_Platform.SelectedItem = selectedGame.Platform;
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

        
    }
}


