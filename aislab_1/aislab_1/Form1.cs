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
        public MainForm()
        {
            InitializeComponent();
            //
        }

        // Этот метод будет вызываться при загрузке формы
        /// <summary>
        /// Обработчик события загрузки формы. Вызывается один раз при первом открытии окна.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            SetupInputControls();
            SetupDataGridView();
            UpdateGamesGrid();
        }

        /// <summary>
        /// Настраивает выпадающие списки (ComboBox) и поля для ввода чисел (NumericUpDown).
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
        /// Настраивает колонки и внешний вид таблицы DataGridView для отображения игр.
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Название", DataPropertyName = "Title" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Жанр", DataPropertyName = "GameGenre" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Платформа", DataPropertyName = "Platform" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Рейтинг", DataPropertyName = "Rating" });
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        // === 2. ОСНОВНЫЕ МЕТОДЫ ДЛЯ РАБОТЫ С ДАННЫМИ ===

        /// <summary>
        /// Обновляет данные в таблице, запрашивая актуальный список из бизнес-логики.
        /// </summary>
        private void UpdateGamesGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = logic.Games;
        }

        /// <summary>
        /// Очищает все поля ввода справа, возвращая их в состояние по умолчанию.
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
        }


        // === 3. ОБРАБОТЧИКИ СОБЫТИЙ ===

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить".
        /// </summary>
        private void button_Add_Click(object sender, EventArgs e)
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
        /// Обработчик нажатия кнопки "Изменить".
        /// </summary>
        private void button_Change_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Game selectedGame = dataGridView1.SelectedRows[0].DataBoundItem as Game;
                if (selectedGame != null)
                {
                    string newTitle = textBox_Title.Text;
                    int newRating = (int)numericUpDown_Rating.Value;
                    logic.ChangeGame(selectedGame.Id, newTitle, newRating);
                    UpdateGamesGrid();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите игру для изменения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить".
        /// </summary>
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var confirmation = MessageBox.Show("Вы уверены, что хотите удалить эту игру?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    Game selectedGame = dataGridView1.SelectedRows[0].DataBoundItem as Game;
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
                MessageBox.Show("Пожалуйста, выберите игру для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Фильтровать".
        /// </summary>
        private void button_Filter_Click(object sender, EventArgs e)
        {
            string selectedPlatform = comboBox_Platform.SelectedItem.ToString();
            string result = logic.GetGamesByPlatform(selectedPlatform);
            MessageBox.Show(result, $"Игры на платформе: {selectedPlatform}");
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Группировать".
        /// </summary>
        private void button_Group_Click(object sender, EventArgs e)
        {
            string result = logic.GetGamesGroupedByGenre();
            MessageBox.Show(result, "Группировка по жанрам");
        }

        /// <summary>
        /// Обработчик смены выделенной строки в таблице.
        /// </summary>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Game selectedGame = dataGridView1.SelectedRows[0].DataBoundItem as Game;
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
        }
    }
}
