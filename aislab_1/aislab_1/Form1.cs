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
using Controller;


namespace aislab_1
{
    /// <summary>
    /// Главная форма приложения, реализующая интерфейс IGameView
    /// Является пассивным представлением (Passive View), которое только отображает данные
    /// и передает действия пользователя в Presenter через события
    /// </summary>
    public partial class MainForm : Form
    {
        private GameController _controller;
        private IGameService _service;

        private DataGridViewRow selectedRow = null;
        private BindingSource gamesBinding = new BindingSource();
        private List<Platform> _cachedPlatforms;


        public MainForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        public void Configure(GameController controller, IGameService service)
        {
            _controller = controller;
            _service = service;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupInputControls();
            SetupDataGridView();
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                // 1. Получаем список игр
                var games = _service.GetAllGames();
                gamesBinding.DataSource = games.ToList();

                // 2. Получаем список платформ
                var platforms = _service.GetAllPlatforms().ToList();
                _cachedPlatforms = platforms;

                // 3. Обновляем выпадающий список платформ
                // (сбрасываем DataSource, чтобы обновилось содержимое)
                Guid? selectedId = null;
                if (comboBox_Platform.SelectedValue is Guid id) selectedId = id;

                comboBox_Platform.DataSource = null;
                comboBox_Platform.DataSource = _cachedPlatforms;
                comboBox_Platform.DisplayMember = "Name";
                comboBox_Platform.ValueMember = "Id";

                // Пытаемся восстановить выбор
                if (selectedId.HasValue && _cachedPlatforms.Any(p => p.Id == selectedId.Value))
                {
                    comboBox_Platform.SelectedValue = selectedId.Value;
                }

                // 4. Сбрасываем выделение в таблице
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.ClearSelection();
                }
                selectedRow = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. View собирает данные
                string title = textBox_Title.Text;
                Genre genre = (Genre)comboBox_Genre.SelectedItem;
                string dev = textBox_Developer.Text;
                int year = (int)numericUpDown_ReleaseYear.Value;
                Guid platId = (Guid)comboBox_Platform.SelectedValue;
                int rating = (int)numericUpDown_Rating.Value;

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(dev))
                {
                    MessageBox.Show("Название и разработчик не могут быть пустыми!");
                    return;
                }

                // 2. View вызывает Контроллер ("Сделай изменение")
                _controller.AddGame(title, genre, dev, year, platId, rating);

                // 3. View сама обновляет себя ("Покажи результат")
                RefreshData();
                ClearInputFields();
                MessageBox.Show("Игра успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Change_Click(object sender, EventArgs e)
        {
            if (selectedRow?.DataBoundItem is Game selectedGame)
            {
                try
                {
                    // 1. Контроллер обновляет
                    _controller.UpdateGame(
                        selectedGame.Id,
                        textBox_Title.Text,
                        (int)numericUpDown_Rating.Value,
                        (Guid)comboBox_Platform.SelectedValue,
                        textBox_Developer.Text,
                        (Genre)comboBox_Genre.SelectedItem
                    );

                    // 2. View обновляется
                    RefreshData();
                    MessageBox.Show("Игра обновлена!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите игру для изменения.");
            }
        }


        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (selectedRow?.DataBoundItem is Game selectedGame)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить эту игру?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // 1. Контроллер удаляет
                        _controller.DeleteGame(selectedGame.Id);

                        // 2. View обновляется
                        RefreshData();
                        ClearInputFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите игру для удаления.");
            }
        }

        private void Button_Filter_Click(object sender, EventArgs e)
        {
            if (comboBox_Platform.SelectedValue != null)
            {
                Guid platformId = (Guid)comboBox_Platform.SelectedValue;
                // Прямой запрос к сервису
                var filtered = _service.GetGamesByPlatform(platformId);
                gamesBinding.DataSource = filtered.ToList();
            }
        }

        private void Button_Group_Click(object sender, EventArgs e)
        {
            // Сортировка на стороне клиента или запрос к сервису
            var games = _service.GetAllGames();
            var sorted = games.OrderBy(g => g.GameGenre).ThenBy(g => g.Title).ToList();
            gamesBinding.DataSource = sorted;
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            RefreshData(); // Сброс к полному списку
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void buttonAddPlatform_Click(object sender, EventArgs e)
        {
            string newPlatform = textBoxPlatformSearch.Text;
            if (string.IsNullOrWhiteSpace(newPlatform)) return;

            try
            {
                _controller.AddPlatform(newPlatform);
                RefreshData(); // Обновит список платформ в комбобоксе
                textBoxPlatformSearch.Clear();
                MessageBox.Show("Платформа добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnSearchByPlatform_Click(object sender, EventArgs e)
        {
            string name = txtPlatformSearch.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                var found = _service.FindGamesByPlatformName(name);
                gamesBinding.DataSource = found.ToList();
            }
        }
        

        
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
            else
            {
                selectedRow = null;
                ClearInputFields();
            }
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value is Platform platform) 
            { 
                e.Value = platform.Name; e.FormattingApplied = true; 
            }
        }

        private void ClearInputFields()
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


    }
}

