namespace aislab_1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox_GameProps = new System.Windows.Forms.GroupBox();
            this.numericUpDown_Rating = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ReleaseYear = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Platform = new System.Windows.Forms.ComboBox();
            this.comboBox_Genre = new System.Windows.Forms.ComboBox();
            this.textBox_Developer = new System.Windows.Forms.TextBox();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.label_Rating = new System.Windows.Forms.Label();
            this.label_ReleaseYear = new System.Windows.Forms.Label();
            this.label_Platform = new System.Windows.Forms.Label();
            this.label_Genre = new System.Windows.Forms.Label();
            this.label_Developer = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Filter = new System.Windows.Forms.Button();
            this.button_Group = new System.Windows.Forms.Button();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAddPlatform = new System.Windows.Forms.Button();
            this.textBoxPlatformSearch = new System.Windows.Forms.TextBox();
            this.btnSearchByPlatform = new System.Windows.Forms.Button();
            this.txtPlatformSearch = new System.Windows.Forms.TextBox();
            this.gbListActions = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.separator1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_GameProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Rating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReleaseYear)).BeginInit();
            this.gbListActions.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(1069, 1160);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox_GameProps
            // 
            this.groupBox_GameProps.Controls.Add(this.numericUpDown_Rating);
            this.groupBox_GameProps.Controls.Add(this.numericUpDown_ReleaseYear);
            this.groupBox_GameProps.Controls.Add(this.comboBox_Platform);
            this.groupBox_GameProps.Controls.Add(this.comboBox_Genre);
            this.groupBox_GameProps.Controls.Add(this.textBox_Developer);
            this.groupBox_GameProps.Controls.Add(this.textBox_Title);
            this.groupBox_GameProps.Controls.Add(this.label_Rating);
            this.groupBox_GameProps.Controls.Add(this.label_ReleaseYear);
            this.groupBox_GameProps.Controls.Add(this.label_Platform);
            this.groupBox_GameProps.Controls.Add(this.label_Genre);
            this.groupBox_GameProps.Controls.Add(this.label_Developer);
            this.groupBox_GameProps.Controls.Add(this.label_Title);
            this.groupBox_GameProps.Location = new System.Drawing.Point(1118, 15);
            this.groupBox_GameProps.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_GameProps.Name = "groupBox_GameProps";
            this.groupBox_GameProps.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_GameProps.Size = new System.Drawing.Size(708, 634);
            this.groupBox_GameProps.TabIndex = 1;
            this.groupBox_GameProps.TabStop = false;
            this.groupBox_GameProps.Text = "Информация об игре";
            // 
            // numericUpDown_Rating
            // 
            this.numericUpDown_Rating.Location = new System.Drawing.Point(236, 583);
            this.numericUpDown_Rating.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDown_Rating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Rating.Name = "numericUpDown_Rating";
            this.numericUpDown_Rating.Size = new System.Drawing.Size(240, 31);
            this.numericUpDown_Rating.TabIndex = 11;
            // 
            // numericUpDown_ReleaseYear
            // 
            this.numericUpDown_ReleaseYear.Location = new System.Drawing.Point(236, 475);
            this.numericUpDown_ReleaseYear.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDown_ReleaseYear.Maximum = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.numericUpDown_ReleaseYear.Minimum = new decimal(new int[] {
            1980,
            0,
            0,
            0});
            this.numericUpDown_ReleaseYear.Name = "numericUpDown_ReleaseYear";
            this.numericUpDown_ReleaseYear.Size = new System.Drawing.Size(240, 31);
            this.numericUpDown_ReleaseYear.TabIndex = 10;
            this.numericUpDown_ReleaseYear.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // comboBox_Platform
            // 
            this.comboBox_Platform.FormattingEnabled = true;
            this.comboBox_Platform.Location = new System.Drawing.Point(236, 358);
            this.comboBox_Platform.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_Platform.Name = "comboBox_Platform";
            this.comboBox_Platform.Size = new System.Drawing.Size(238, 33);
            this.comboBox_Platform.TabIndex = 9;
            // 
            // comboBox_Genre
            // 
            this.comboBox_Genre.FormattingEnabled = true;
            this.comboBox_Genre.Location = new System.Drawing.Point(236, 256);
            this.comboBox_Genre.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_Genre.Name = "comboBox_Genre";
            this.comboBox_Genre.Size = new System.Drawing.Size(238, 33);
            this.comboBox_Genre.TabIndex = 8;
            // 
            // textBox_Developer
            // 
            this.textBox_Developer.Location = new System.Drawing.Point(236, 158);
            this.textBox_Developer.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Developer.Name = "textBox_Developer";
            this.textBox_Developer.Size = new System.Drawing.Size(460, 31);
            this.textBox_Developer.TabIndex = 7;
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(236, 54);
            this.textBox_Title.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(460, 31);
            this.textBox_Title.TabIndex = 6;
            // 
            // label_Rating
            // 
            this.label_Rating.AutoSize = true;
            this.label_Rating.Location = new System.Drawing.Point(34, 585);
            this.label_Rating.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_Rating.Name = "label_Rating";
            this.label_Rating.Size = new System.Drawing.Size(92, 25);
            this.label_Rating.TabIndex = 5;
            this.label_Rating.Text = "Рейтинг";
            // 
            // label_ReleaseYear
            // 
            this.label_ReleaseYear.AutoSize = true;
            this.label_ReleaseYear.Location = new System.Drawing.Point(34, 475);
            this.label_ReleaseYear.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_ReleaseYear.Name = "label_ReleaseYear";
            this.label_ReleaseYear.Size = new System.Drawing.Size(127, 25);
            this.label_ReleaseYear.TabIndex = 4;
            this.label_ReleaseYear.Text = "Год выхода";
            // 
            // label_Platform
            // 
            this.label_Platform.AutoSize = true;
            this.label_Platform.Location = new System.Drawing.Point(34, 363);
            this.label_Platform.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_Platform.Name = "label_Platform";
            this.label_Platform.Size = new System.Drawing.Size(129, 25);
            this.label_Platform.TabIndex = 3;
            this.label_Platform.Text = "Платформа";
            // 
            // label_Genre
            // 
            this.label_Genre.AutoSize = true;
            this.label_Genre.Location = new System.Drawing.Point(34, 262);
            this.label_Genre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_Genre.Name = "label_Genre";
            this.label_Genre.Size = new System.Drawing.Size(67, 25);
            this.label_Genre.TabIndex = 2;
            this.label_Genre.Text = "Жанр";
            // 
            // label_Developer
            // 
            this.label_Developer.AutoSize = true;
            this.label_Developer.Location = new System.Drawing.Point(34, 163);
            this.label_Developer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_Developer.Name = "label_Developer";
            this.label_Developer.Size = new System.Drawing.Size(141, 25);
            this.label_Developer.TabIndex = 1;
            this.label_Developer.Text = "Разработчик";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(34, 60);
            this.label_Title.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(109, 25);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Название";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(70, 15);
            this.button_Add.Margin = new System.Windows.Forms.Padding(70, 15, 8, 30);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(150, 44);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(278, 15);
            this.button_Change.Margin = new System.Windows.Forms.Padding(50, 15, 50, 30);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(150, 44);
            this.button_Change.TabIndex = 3;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.Button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(486, 15);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(8, 15, 8, 30);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(150, 44);
            this.button_Delete.TabIndex = 4;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // button_Filter
            // 
            this.button_Filter.Location = new System.Drawing.Point(10, 20);
            this.button_Filter.Margin = new System.Windows.Forms.Padding(10, 20, 20, 6);
            this.button_Filter.Name = "button_Filter";
            this.button_Filter.Size = new System.Drawing.Size(170, 44);
            this.button_Filter.TabIndex = 5;
            this.button_Filter.Text = "Фильтровать";
            this.button_Filter.UseVisualStyleBackColor = true;
            this.button_Filter.Click += new System.EventHandler(this.Button_Filter_Click);
            // 
            // button_Group
            // 
            this.button_Group.Location = new System.Drawing.Point(206, 20);
            this.button_Group.Margin = new System.Windows.Forms.Padding(6, 20, 20, 6);
            this.button_Group.Name = "button_Group";
            this.button_Group.Size = new System.Drawing.Size(170, 44);
            this.button_Group.TabIndex = 6;
            this.button_Group.Text = "Группировать";
            this.button_Group.UseVisualStyleBackColor = true;
            this.button_Group.Click += new System.EventHandler(this.Button_Group_Click);
            // 
            // Button_Reset
            // 
            this.Button_Reset.Location = new System.Drawing.Point(556, 20);
            this.Button_Reset.Margin = new System.Windows.Forms.Padding(6, 20, 6, 6);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(126, 44);
            this.Button_Reset.TabIndex = 7;
            this.Button_Reset.Text = "Сбросить";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(400, 20);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 20, 20, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(130, 44);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAddPlatform
            // 
            this.buttonAddPlatform.Location = new System.Drawing.Point(197, 58);
            this.buttonAddPlatform.Margin = new System.Windows.Forms.Padding(197, 6, 197, 4);
            this.buttonAddPlatform.Name = "buttonAddPlatform";
            this.buttonAddPlatform.Size = new System.Drawing.Size(308, 44);
            this.buttonAddPlatform.TabIndex = 9;
            this.buttonAddPlatform.Text = "Добавить платформу";
            this.buttonAddPlatform.UseVisualStyleBackColor = true;
            this.buttonAddPlatform.Click += new System.EventHandler(this.buttonAddPlatform_Click);
            // 
            // textBoxPlatformSearch
            // 
            this.textBoxPlatformSearch.Location = new System.Drawing.Point(231, 15);
            this.textBoxPlatformSearch.Margin = new System.Windows.Forms.Padding(231, 15, 231, 6);
            this.textBoxPlatformSearch.Name = "textBoxPlatformSearch";
            this.textBoxPlatformSearch.Size = new System.Drawing.Size(240, 31);
            this.textBoxPlatformSearch.TabIndex = 12;
            // 
            // btnSearchByPlatform
            // 
            this.btnSearchByPlatform.Location = new System.Drawing.Point(118, 59);
            this.btnSearchByPlatform.Margin = new System.Windows.Forms.Padding(118, 10, 118, 3);
            this.btnSearchByPlatform.Name = "btnSearchByPlatform";
            this.btnSearchByPlatform.Size = new System.Drawing.Size(466, 44);
            this.btnSearchByPlatform.TabIndex = 13;
            this.btnSearchByPlatform.Text = "Найти по названию платформы";
            this.btnSearchByPlatform.UseVisualStyleBackColor = true;
            this.btnSearchByPlatform.Click += new System.EventHandler(this.btnSearchByPlatform_Click);
            // 
            // txtPlatformSearch
            // 
            this.txtPlatformSearch.Location = new System.Drawing.Point(229, 15);
            this.txtPlatformSearch.Margin = new System.Windows.Forms.Padding(229, 15, 229, 3);
            this.txtPlatformSearch.Name = "txtPlatformSearch";
            this.txtPlatformSearch.Size = new System.Drawing.Size(244, 31);
            this.txtPlatformSearch.TabIndex = 14;
            // 
            // gbListActions
            // 
            this.gbListActions.Controls.Add(this.flowLayoutPanel1);
            this.gbListActions.Location = new System.Drawing.Point(1118, 690);
            this.gbListActions.Name = "gbListActions";
            this.gbListActions.Size = new System.Drawing.Size(708, 473);
            this.gbListActions.TabIndex = 15;
            this.gbListActions.TabStop = false;
            this.gbListActions.Text = "Управление списком";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.separator1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(702, 443);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.button_Add);
            this.flowLayoutPanel2.Controls.Add(this.button_Change);
            this.flowLayoutPanel2.Controls.Add(this.button_Delete);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(702, 74);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // separator1
            // 
            this.separator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator1.Location = new System.Drawing.Point(3, 80);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(708, 2);
            this.separator1.TabIndex = 15;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 85);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(708, 225);
            this.flowLayoutPanel3.TabIndex = 17;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.button_Filter);
            this.flowLayoutPanel5.Controls.Add(this.button_Group);
            this.flowLayoutPanel5.Controls.Add(this.buttonUpdate);
            this.flowLayoutPanel5.Controls.Add(this.Button_Reset);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(702, 95);
            this.flowLayoutPanel5.TabIndex = 15;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(708, 2);
            this.label2.TabIndex = 20;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.txtPlatformSearch);
            this.flowLayoutPanel6.Controls.Add(this.btnSearchByPlatform);
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 106);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(702, 121);
            this.flowLayoutPanel6.TabIndex = 21;
            this.flowLayoutPanel6.WrapContents = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(3, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(708, 2);
            this.label1.TabIndex = 18;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.textBoxPlatformSearch);
            this.flowLayoutPanel4.Controls.Add(this.buttonAddPlatform);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 318);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(702, 117);
            this.flowLayoutPanel4.TabIndex = 19;
            this.flowLayoutPanel4.WrapContents = false;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(3, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(708, 2);
            this.label3.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1841, 1210);
            this.Controls.Add(this.gbListActions);
            this.Controls.Add(this.groupBox_GameProps);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Библиотека игр";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_GameProps.ResumeLayout(false);
            this.groupBox_GameProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Rating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReleaseYear)).EndInit();
            this.gbListActions.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox_GameProps;
        private System.Windows.Forms.Label label_ReleaseYear;
        private System.Windows.Forms.Label label_Platform;
        private System.Windows.Forms.Label label_Genre;
        private System.Windows.Forms.Label label_Developer;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Rating;
        private System.Windows.Forms.TextBox textBox_Developer;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.ComboBox comboBox_Platform;
        private System.Windows.Forms.ComboBox comboBox_Genre;
        private System.Windows.Forms.NumericUpDown numericUpDown_Rating;
        private System.Windows.Forms.NumericUpDown numericUpDown_ReleaseYear;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Filter;
        private System.Windows.Forms.Button button_Group;
        private System.Windows.Forms.Button Button_Reset;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAddPlatform;
        private System.Windows.Forms.TextBox textBoxPlatformSearch;
        private System.Windows.Forms.Button btnSearchByPlatform;
        private System.Windows.Forms.TextBox txtPlatformSearch;
        private System.Windows.Forms.GroupBox gbListActions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label separator1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
    }
}

