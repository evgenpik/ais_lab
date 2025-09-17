namespace aislab_1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox_GameProps = new System.Windows.Forms.GroupBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Developer = new System.Windows.Forms.Label();
            this.label_Genre = new System.Windows.Forms.Label();
            this.label_Platform = new System.Windows.Forms.Label();
            this.label_ReleaseYear = new System.Windows.Forms.Label();
            this.label_Rating = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_Developer = new System.Windows.Forms.TextBox();
            this.comboBox_Genre = new System.Windows.Forms.ComboBox();
            this.comboBox_Platform = new System.Windows.Forms.ComboBox();
            this.numericUpDown_ReleaseYear = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Rating = new System.Windows.Forms.NumericUpDown();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Filter = new System.Windows.Forms.Button();
            this.button_Group = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_GameProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReleaseYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Rating)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(366, 454);
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
            this.groupBox_GameProps.Location = new System.Drawing.Point(372, 13);
            this.groupBox_GameProps.Name = "groupBox_GameProps";
            this.groupBox_GameProps.Size = new System.Drawing.Size(357, 360);
            this.groupBox_GameProps.TabIndex = 1;
            this.groupBox_GameProps.TabStop = false;
            this.groupBox_GameProps.Text = "Информация об игре";
            this.groupBox_GameProps.Enter += new System.EventHandler(this.groupBox_GameProps_Enter);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(17, 31);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(57, 13);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Название";
            // 
            // label_Developer
            // 
            this.label_Developer.AutoSize = true;
            this.label_Developer.Location = new System.Drawing.Point(17, 85);
            this.label_Developer.Name = "label_Developer";
            this.label_Developer.Size = new System.Drawing.Size(72, 13);
            this.label_Developer.TabIndex = 1;
            this.label_Developer.Text = "Разработчик";
            // 
            // label_Genre
            // 
            this.label_Genre.AutoSize = true;
            this.label_Genre.Location = new System.Drawing.Point(17, 136);
            this.label_Genre.Name = "label_Genre";
            this.label_Genre.Size = new System.Drawing.Size(36, 13);
            this.label_Genre.TabIndex = 2;
            this.label_Genre.Text = "Жанр";
            // 
            // label_Platform
            // 
            this.label_Platform.AutoSize = true;
            this.label_Platform.Location = new System.Drawing.Point(17, 189);
            this.label_Platform.Name = "label_Platform";
            this.label_Platform.Size = new System.Drawing.Size(66, 13);
            this.label_Platform.TabIndex = 3;
            this.label_Platform.Text = "Платформа";
            // 
            // label_ReleaseYear
            // 
            this.label_ReleaseYear.AutoSize = true;
            this.label_ReleaseYear.Location = new System.Drawing.Point(17, 247);
            this.label_ReleaseYear.Name = "label_ReleaseYear";
            this.label_ReleaseYear.Size = new System.Drawing.Size(65, 13);
            this.label_ReleaseYear.TabIndex = 4;
            this.label_ReleaseYear.Text = "Год выхода";
            // 
            // label_Rating
            // 
            this.label_Rating.AutoSize = true;
            this.label_Rating.Location = new System.Drawing.Point(17, 310);
            this.label_Rating.Name = "label_Rating";
            this.label_Rating.Size = new System.Drawing.Size(48, 13);
            this.label_Rating.TabIndex = 5;
            this.label_Rating.Text = "Рейтинг";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(118, 28);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(232, 20);
            this.textBox_Title.TabIndex = 6;
            // 
            // textBox_Developer
            // 
            this.textBox_Developer.Location = new System.Drawing.Point(118, 82);
            this.textBox_Developer.Name = "textBox_Developer";
            this.textBox_Developer.Size = new System.Drawing.Size(232, 20);
            this.textBox_Developer.TabIndex = 7;
            // 
            // comboBox_Genre
            // 
            this.comboBox_Genre.FormattingEnabled = true;
            this.comboBox_Genre.Location = new System.Drawing.Point(118, 133);
            this.comboBox_Genre.Name = "comboBox_Genre";
            this.comboBox_Genre.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Genre.TabIndex = 8;
            // 
            // comboBox_Platform
            // 
            this.comboBox_Platform.FormattingEnabled = true;
            this.comboBox_Platform.Location = new System.Drawing.Point(118, 186);
            this.comboBox_Platform.Name = "comboBox_Platform";
            this.comboBox_Platform.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Platform.TabIndex = 9;
            // 
            // numericUpDown_ReleaseYear
            // 
            this.numericUpDown_ReleaseYear.Location = new System.Drawing.Point(118, 247);
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
            // numericUpDown_Rating
            // 
            this.numericUpDown_Rating.Location = new System.Drawing.Point(118, 303);
            this.numericUpDown_Rating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Rating.Name = "numericUpDown_Rating";
            this.numericUpDown_Rating.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Rating.TabIndex = 11;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(379, 380);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(463, 380);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 3;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(551, 380);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 4;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Filter
            // 
            this.button_Filter.Location = new System.Drawing.Point(637, 380);
            this.button_Filter.Name = "button_Filter";
            this.button_Filter.Size = new System.Drawing.Size(85, 23);
            this.button_Filter.TabIndex = 5;
            this.button_Filter.Text = "Фильтровать";
            this.button_Filter.UseVisualStyleBackColor = true;
            // 
            // button_Group
            // 
            this.button_Group.Location = new System.Drawing.Point(503, 409);
            this.button_Group.Name = "button_Group";
            this.button_Group.Size = new System.Drawing.Size(88, 23);
            this.button_Group.TabIndex = 6;
            this.button_Group.Text = "Группировать";
            this.button_Group.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 454);
            this.Controls.Add(this.button_Group);
            this.Controls.Add(this.button_Filter);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox_GameProps);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_GameProps.ResumeLayout(false);
            this.groupBox_GameProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReleaseYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Rating)).EndInit();
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
    }
}

