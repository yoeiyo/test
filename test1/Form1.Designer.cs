namespace test1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.inpFile_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reg_comboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.inpFile_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.log_textBox = new System.Windows.Forms.TextBox();
            this.log_button = new System.Windows.Forms.Button();
            this.res_textBox = new System.Windows.Forms.TextBox();
            this.res_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Входной файл";
            // 
            // inpFile_textBox
            // 
            this.inpFile_textBox.Location = new System.Drawing.Point(12, 28);
            this.inpFile_textBox.Name = "inpFile_textBox";
            this.inpFile_textBox.Size = new System.Drawing.Size(331, 22);
            this.inpFile_textBox.TabIndex = 1;
            this.inpFile_textBox.TextChanged += new System.EventHandler(this.inpFile_textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Район доставки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Время первой доставки";
            // 
            // reg_comboBox
            // 
            this.reg_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reg_comboBox.FormattingEnabled = true;
            this.reg_comboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.reg_comboBox.Location = new System.Drawing.Point(12, 114);
            this.reg_comboBox.Name = "reg_comboBox";
            this.reg_comboBox.Size = new System.Drawing.Size(121, 24);
            this.reg_comboBox.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(235, 116);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 5;
            // 
            // inpFile_button
            // 
            this.inpFile_button.Location = new System.Drawing.Point(349, 24);
            this.inpFile_button.Name = "inpFile_button";
            this.inpFile_button.Size = new System.Drawing.Size(90, 30);
            this.inpFile_button.TabIndex = 2;
            this.inpFile_button.Text = "Обзор...";
            this.inpFile_button.UseVisualStyleBackColor = true;
            this.inpFile_button.Click += new System.EventHandler(this.inpFile_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Путь к лог-файлу";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Путь к файлу с результатом";
            // 
            // log_textBox
            // 
            this.log_textBox.Location = new System.Drawing.Point(12, 213);
            this.log_textBox.Name = "log_textBox";
            this.log_textBox.Size = new System.Drawing.Size(331, 22);
            this.log_textBox.TabIndex = 8;
            this.log_textBox.TextChanged += new System.EventHandler(this.log_textBox_TextChanged);
            // 
            // log_button
            // 
            this.log_button.Location = new System.Drawing.Point(349, 209);
            this.log_button.Name = "log_button";
            this.log_button.Size = new System.Drawing.Size(90, 30);
            this.log_button.TabIndex = 9;
            this.log_button.Text = "Обзор...";
            this.log_button.UseVisualStyleBackColor = true;
            this.log_button.Click += new System.EventHandler(this.log_button_Click);
            // 
            // res_textBox
            // 
            this.res_textBox.Location = new System.Drawing.Point(12, 285);
            this.res_textBox.Name = "res_textBox";
            this.res_textBox.Size = new System.Drawing.Size(331, 22);
            this.res_textBox.TabIndex = 10;
            this.res_textBox.TextChanged += new System.EventHandler(this.res_textBox_TextChanged);
            // 
            // res_button
            // 
            this.res_button.Location = new System.Drawing.Point(349, 281);
            this.res_button.Name = "res_button";
            this.res_button.Size = new System.Drawing.Size(90, 30);
            this.res_button.TabIndex = 11;
            this.res_button.Text = "Обзор...";
            this.res_button.UseVisualStyleBackColor = true;
            this.res_button.Click += new System.EventHandler(this.res_button_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(179, 360);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(90, 30);
            this.start_button.TabIndex = 12;
            this.start_button.Text = "Старт";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 402);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.res_button);
            this.Controls.Add(this.res_textBox);
            this.Controls.Add(this.log_button);
            this.Controls.Add(this.log_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inpFile_button);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.reg_comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inpFile_textBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "служба доставки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inpFile_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox reg_comboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button inpFile_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox log_textBox;
        private System.Windows.Forms.Button log_button;
        private System.Windows.Forms.TextBox res_textBox;
        private System.Windows.Forms.Button res_button;
        private System.Windows.Forms.Button start_button;
    }
}

