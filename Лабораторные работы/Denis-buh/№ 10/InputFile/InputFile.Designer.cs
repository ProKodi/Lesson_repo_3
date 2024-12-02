namespace WindowsFormsApp5.InputFile
{
    partial class InputFile
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.save_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 84);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(279, 72);
            this.textBox1.TabIndex = 0;
            // 
            // save_file
            // 
            this.save_file.Location = new System.Drawing.Point(346, 225);
            this.save_file.Name = "save_file";
            this.save_file.Size = new System.Drawing.Size(153, 23);
            this.save_file.TabIndex = 1;
            this.save_file.Text = "Сохранить файл";
            this.save_file.UseVisualStyleBackColor = true;
            this.save_file.Click += new System.EventHandler(this.save_file_Click);
            // 
            // InputFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 353);
            this.Controls.Add(this.save_file);
            this.Controls.Add(this.textBox1);
            this.Name = "InputFile";
            this.Text = "Ввод файла";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button save_file;
    }
}