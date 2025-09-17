namespace WindowsForms
{
    partial class Form1
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
            this.dgv_Games = new System.Windows.Forms.DataGridView();
            this.groupBox_GameProps = new System.Windows.Forms.GroupBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Filter = new System.Windows.Forms.Button();
            this.button_Group = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Genre = new System.Windows.Forms.Label();
            this.label_Developer = new System.Windows.Forms.Label();
            this.label_Platform = new System.Windows.Forms.Label();
            this.label_Rating = new System.Windows.Forms.Label();
            this.label_ReleaseYear = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_Developer = new System.Windows.Forms.TextBox();
            this.comboBox_Genre = new System.Windows.Forms.ComboBox();
            this.comboBox_Platform = new System.Windows.Forms.ComboBox();
            this.numericUpDown_ReleaseYear = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Games)).BeginInit();
            this.groupBox_GameProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReleaseYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Games
            // 
            this.dgv_Games.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Games.Location = new System.Drawing.Point(1, 0);
            this.dgv_Games.Name = "dgv_Games";
            this.dgv_Games.Size = new System.Drawing.Size(397, 336);
            this.dgv_Games.TabIndex = 0;
            // 
            // groupBox_GameProps
            // 
            this.groupBox_GameProps.Controls.Add(this.numericUpDown2);
            this.groupBox_GameProps.Controls.Add(this.numericUpDown_ReleaseYear);
            this.groupBox_GameProps.Controls.Add(this.comboBox_Platform);
            this.groupBox_GameProps.Controls.Add(this.comboBox_Genre);
            this.groupBox_GameProps.Controls.Add(this.textBox_Developer);
            this.groupBox_GameProps.Controls.Add(this.textBox_Title);
            this.groupBox_GameProps.Controls.Add(this.label_Rating);
            this.groupBox_GameProps.Controls.Add(this.label_ReleaseYear);
            this.groupBox_GameProps.Controls.Add(this.label_Developer);
            this.groupBox_GameProps.Controls.Add(this.label_Platform);
            this.groupBox_GameProps.Controls.Add(this.label_Genre);
            this.groupBox_GameProps.Controls.Add(this.label_Title);
            this.groupBox_GameProps.Location = new System.Drawing.Point(405, 12);
            this.groupBox_GameProps.Name = "groupBox_GameProps";
            this.groupBox_GameProps.Size = new System.Drawing.Size(391, 238);
            this.groupBox_GameProps.TabIndex = 1;
            this.groupBox_GameProps.TabStop = false;
            this.groupBox_GameProps.Text = "Сведения об игре";
            this.groupBox_GameProps.Enter += new System.EventHandler(this.groupBox_GameProps_Enter);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(409, 265);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(85, 23);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(508, 265);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(85, 23);
            this.button_Delete.TabIndex = 3;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(605, 265);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(85, 23);
            this.button_Change.TabIndex = 4;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            // 
            // button_Filter
            // 
            this.button_Filter.Location = new System.Drawing.Point(707, 265);
            this.button_Filter.Name = "button_Filter";
            this.button_Filter.Size = new System.Drawing.Size(85, 23);
            this.button_Filter.TabIndex = 5;
            this.button_Filter.Text = "Фильтр";
            this.button_Filter.UseVisualStyleBackColor = true;
            // 
            // button_Group
            // 
            this.button_Group.Location = new System.Drawing.Point(557, 294);
            this.button_Group.Name = "button_Group";
            this.button_Group.Size = new System.Drawing.Size(85, 23);
            this.button_Group.TabIndex = 6;
            this.button_Group.Text = "Группировать";
            this.button_Group.UseVisualStyleBackColor = true;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(16, 32);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(57, 13);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Название";
            // 
            // label_Genre
            // 
            this.label_Genre.AutoSize = true;
            this.label_Genre.Location = new System.Drawing.Point(17, 102);
            this.label_Genre.Name = "label_Genre";
            this.label_Genre.Size = new System.Drawing.Size(36, 13);
            this.label_Genre.TabIndex = 1;
            this.label_Genre.Text = "Жанр";
            // 
            // label_Developer
            // 
            this.label_Developer.AutoSize = true;
            this.label_Developer.Location = new System.Drawing.Point(17, 64);
            this.label_Developer.Name = "label_Developer";
            this.label_Developer.Size = new System.Drawing.Size(72, 13);
            this.label_Developer.TabIndex = 3;
            this.label_Developer.Text = "Разработчик";
            this.label_Developer.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_Platform
            // 
            this.label_Platform.AutoSize = true;
            this.label_Platform.Location = new System.Drawing.Point(16, 136);
            this.label_Platform.Name = "label_Platform";
            this.label_Platform.Size = new System.Drawing.Size(66, 13);
            this.label_Platform.TabIndex = 2;
            this.label_Platform.Text = "Платформа";
            this.label_Platform.Click += new System.EventHandler(this.label_Platform_Click);
            // 
            // label_Rating
            // 
            this.label_Rating.AutoSize = true;
            this.label_Rating.Location = new System.Drawing.Point(16, 196);
            this.label_Rating.Name = "label_Rating";
            this.label_Rating.Size = new System.Drawing.Size(48, 13);
            this.label_Rating.TabIndex = 5;
            this.label_Rating.Text = "Рейтинг";
            this.label_Rating.Click += new System.EventHandler(this.label4_Click);
            // 
            // label_ReleaseYear
            // 
            this.label_ReleaseYear.AutoSize = true;
            this.label_ReleaseYear.Location = new System.Drawing.Point(17, 164);
            this.label_ReleaseYear.Name = "label_ReleaseYear";
            this.label_ReleaseYear.Size = new System.Drawing.Size(65, 13);
            this.label_ReleaseYear.TabIndex = 4;
            this.label_ReleaseYear.Text = "Год выхода";
            this.label_ReleaseYear.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(112, 32);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(271, 20);
            this.textBox_Title.TabIndex = 6;
            // 
            // textBox_Developer
            // 
            this.textBox_Developer.Location = new System.Drawing.Point(113, 64);
            this.textBox_Developer.Name = "textBox_Developer";
            this.textBox_Developer.Size = new System.Drawing.Size(271, 20);
            this.textBox_Developer.TabIndex = 7;
            // 
            // comboBox_Genre
            // 
            this.comboBox_Genre.FormattingEnabled = true;
            this.comboBox_Genre.Location = new System.Drawing.Point(112, 94);
            this.comboBox_Genre.Name = "comboBox_Genre";
            this.comboBox_Genre.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Genre.TabIndex = 8;
            // 
            // comboBox_Platform
            // 
            this.comboBox_Platform.FormattingEnabled = true;
            this.comboBox_Platform.Location = new System.Drawing.Point(112, 128);
            this.comboBox_Platform.Name = "comboBox_Platform";
            this.comboBox_Platform.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Platform.TabIndex = 9;
            this.comboBox_Platform.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numericUpDown_ReleaseYear
            // 
            this.numericUpDown_ReleaseYear.Location = new System.Drawing.Point(113, 162);
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
            this.numericUpDown_ReleaseYear.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_ReleaseYear.TabIndex = 10;
            this.numericUpDown_ReleaseYear.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(112, 196);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 336);
            this.Controls.Add(this.button_Group);
            this.Controls.Add(this.button_Filter);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox_GameProps);
            this.Controls.Add(this.dgv_Games);
            this.Name = "Form1";
            this.Text = "Библиотека игр";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Games)).EndInit();
            this.groupBox_GameProps.ResumeLayout(false);
            this.groupBox_GameProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReleaseYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Games;
        private System.Windows.Forms.GroupBox groupBox_GameProps;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Filter;
        private System.Windows.Forms.Button button_Group;
        private System.Windows.Forms.Label label_Rating;
        private System.Windows.Forms.Label label_ReleaseYear;
        private System.Windows.Forms.Label label_Developer;
        private System.Windows.Forms.Label label_Platform;
        private System.Windows.Forms.Label label_Genre;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.ComboBox comboBox_Platform;
        private System.Windows.Forms.ComboBox comboBox_Genre;
        private System.Windows.Forms.TextBox textBox_Developer;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown_ReleaseYear;
    }
}

