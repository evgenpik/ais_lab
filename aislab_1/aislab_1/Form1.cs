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
using Shared;


namespace aislab_1
{
    /// <summary>
    /// Главная форма приложения, реализующая интерфейс IGameView
    /// Является пассивным представлением (Passive View), которое только отображает данные
    /// и передает действия пользователя в Presenter через события
    /// </summary>
    public partial class MainForm : Form, IGameView
    {

        private DataGridViewRow selectedRow = null;
        private BindingSource gamesBinding = new BindingSource();
        private List<Platform> _cachedPlatforms;

        #region События IGameView

        /// <summary>
        /// События, возникающее при запросе на добавление, удаление, обновление, фильтрацию, группировку, 
        /// поиск по платформе, сброс, добавление новой платформы, полное обновление данных 
        /// выбранной игры
        /// </summary>
        public event EventHandler AddGameRequested;
        public event EventHandler<Guid> DeleteGameRequested;
        public event EventHandler<GameUpdateEventArgs> UpdateGameRequested;
        public event EventHandler<Guid> FilterByPlatformRequested;
        public event EventHandler<string> FilterByPlatformNameRequested;
        public event EventHandler GroupByGenreRequested;
        public event EventHandler ResetFilterRequested;
        public event EventHandler<string> AddPlatformRequested;
        public event EventHandler RefreshRequested;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupInputControls();
            SetupDataGridView();
            RefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        #region Реализация IGameView

        // Свойства для получения данных из UI
        public string GameTitle => textBox_Title.Text;
        public Genre SelectedGenre => (Genre)comboBox_Genre.SelectedItem;
        public string Developer => textBox_Developer.Text;
        public int ReleaseYear => (int)numericUpDown_ReleaseYear.Value;
        public Guid SelectedPlatformId => (Guid)comboBox_Platform.SelectedValue;
        public int Rating => (int)numericUpDown_Rating.Value;

        /// <summary>
        /// Отображает переданный список игр в таблице DataGridView
        /// </summary>
        /// <param name="games"> Коллекция игр для отображения </param>
        public void ShowGames(IEnumerable<Game> games)
        {
            gamesBinding.DataSource = games.ToList();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
            }
        }

        /// <summary>
        /// Заполняет выпадающий список платформ переданными данными
        /// </summary>
        /// <param name="platforms"> Коллекция платформ для отображения </param>
        public void ShowPlatforms(IEnumerable<Platform> platforms)
        {
            _cachedPlatforms = platforms.ToList();
            comboBox_Platform.DataSource = null;
            comboBox_Platform.DataSource = _cachedPlatforms;
            comboBox_Platform.DisplayMember = "Name";
            comboBox_Platform.ValueMember = "Id";
        }

        /// <summary>
        /// Отображает диалоговое окно с сообщением об ошибке
        /// </summary>
        /// <param name="message"> Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Ну кароч тож самое ток информация
        /// </summary>
        /// <param name="message"></param>
        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearInputFields()
        {
            textBox_Title.Clear();
            textBox_Developer.Clear();
            if (comboBox_Genre.Items.Count > 0) comboBox_Genre.SelectedIndex = 0;
            if (comboBox_Platform.Items.Count > 0) comboBox_Platform.SelectedIndex = 0;
            numericUpDown_ReleaseYear.Value = DateTime.Now.Year;
            numericUpDown_Rating.Value = 1;
            dataGridView1.ClearSelection();
            selectedRow = null;
        }
        public void RefreshUI() { }
        #endregion

        #region Генерация событий из UI
        private void Button_Add_Click(object sender, EventArgs e)
        {
            AddGameRequested?.Invoke(this, EventArgs.Empty);
        }

        private void Button_Change_Click(object sender, EventArgs e)
        {
            if (selectedRow?.DataBoundItem is Game selectedGame)
            {
                var args = new GameUpdateEventArgs
                {
                    Id = selectedGame.Id,
                    Title = this.GameTitle,
                    Rating = this.Rating,
                    PlatformId = this.SelectedPlatformId,
                    Developer = this.Developer,
                    Genre = this.SelectedGenre
                };
                UpdateGameRequested?.Invoke(this, args);
            }
            else 
            { 
                ShowError("Пожалуйста, выберите игру для изменения."); 
            }
        }


        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (selectedRow?.DataBoundItem is Game selectedGame)
            {
                if (MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    DeleteGameRequested?.Invoke(this, selectedGame.Id);
            }
            else
            {
                ShowError("Пожалуйста, выберите игру для удаления.");
            }
        }

        private void Button_Filter_Click(object sender, EventArgs e)
        {
            FilterByPlatformRequested?.Invoke(this, SelectedPlatformId);
        }

        private void Button_Group_Click(object sender, EventArgs e)
        {
            GroupByGenreRequested?.Invoke(this, EventArgs.Empty);
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            ResetFilterRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            RefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonAddPlatform_Click(object sender, EventArgs e)
        {
            AddPlatformRequested?.Invoke(this, textBoxPlatformSearch.Text);
            textBoxPlatformSearch.Clear();
        }

        private void btnSearchByPlatform_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlatformSearch.Text))
            {
                ShowError("Введите имя платформы.");
            }
            else
            {
                FilterByPlatformNameRequested?.Invoke(this, txtPlatformSearch.Text);
            }
           


        }
        #endregion

        #region Настройка и служебные методы UI
        private void SetupInputControls()
        {
            comboBox_Genre.DataSource = Enum.GetValues(typeof(Genre));
            numericUpDown_Rating.Minimum = 1;
            numericUpDown_Rating.Maximum = 10;
            numericUpDown_ReleaseYear.Minimum = 1970;
            numericUpDown_ReleaseYear.Maximum = DateTime.Now.Year;
            numericUpDown_ReleaseYear.Value = DateTime.Now.Year;
        }
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
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.DataBoundItem is Game selectedGame)
                {
                    textBox_Title.Text = selectedGame.Title;
                    textBox_Developer.Text = selectedGame.Developer;
                    comboBox_Genre.SelectedItem = selectedGame.GameGenre;
                    comboBox_Platform.SelectedValue = selectedGame.PlatformId;
                    numericUpDown_ReleaseYear.Value = selectedGame.ReleaseYear;
                    numericUpDown_Rating.Value = selectedGame.Rating;
                }
            }
            else selectedRow = null;
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value is Platform platform) { e.Value = platform.Name; e.FormattingApplied = true; }
        }
        #endregion


        
    }
}


