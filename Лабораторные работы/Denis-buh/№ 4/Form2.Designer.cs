partial class Form2
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBox1 = new GroupBox();
        mode_random_true = new RadioButton();
        mode_random_false = new RadioButton();
        org = new NumericUpDown();
        modl = new NumericUpDown();
        arg_for_fun = new NumericUpDown();
        label9 = new Label();
        fun = new ComboBox();
        label8 = new Label();
        to_calculate = new Button();
        y_number = new TextBox();
        x_number = new TextBox();
        number = new TextBox();
        label7 = new Label();
        label6 = new Label();
        label5 = new Label();
        label2 = new Label();
        label1 = new Label();
        groupBox2 = new GroupBox();
        groupBox3 = new GroupBox();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)org).BeginInit();
        ((System.ComponentModel.ISupportInitialize)modl).BeginInit();
        ((System.ComponentModel.ISupportInitialize)arg_for_fun).BeginInit();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(mode_random_true);
        groupBox1.Controls.Add(mode_random_false);
        groupBox1.Location = new Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(200, 100);
        groupBox1.TabIndex = 25;
        groupBox1.TabStop = false;
        groupBox1.Text = "Как будут заданы данные";
        // 
        // mode_random_true
        // 
        mode_random_true.AutoSize = true;
        mode_random_true.Checked = true;
        mode_random_true.Location = new Point(6, 22);
        mode_random_true.Name = "mode_random_true";
        mode_random_true.Size = new Size(80, 19);
        mode_random_true.TabIndex = 23;
        mode_random_true.TabStop = true;
        mode_random_true.Text = "Случайно";
        mode_random_true.UseVisualStyleBackColor = true;
        mode_random_true.CheckedChanged += mode_random_true_CheckedChanged;
        // 
        // mode_random_false
        // 
        mode_random_false.AutoSize = true;
        mode_random_false.Location = new Point(6, 47);
        mode_random_false.Name = "mode_random_false";
        mode_random_false.Size = new Size(176, 19);
        mode_random_false.TabIndex = 24;
        mode_random_false.Text = "Те что указал пользователь";
        mode_random_false.UseVisualStyleBackColor = true;
        mode_random_false.CheckedChanged += mode_random_false_CheckedChanged;
        // 
        // org
        // 
        org.BackColor = SystemColors.ScrollBar;
        org.Location = new Point(112, 53);
        org.Name = "org";
        org.Size = new Size(116, 23);
        org.TabIndex = 22;
        // 
        // modl
        // 
        modl.BackColor = SystemColors.InactiveCaption;
        modl.Location = new Point(112, 19);
        modl.Name = "modl";
        modl.Size = new Size(116, 23);
        modl.TabIndex = 21;
        // 
        // arg_for_fun
        // 
        arg_for_fun.BackColor = SystemColors.InactiveBorder;
        arg_for_fun.Location = new Point(248, 93);
        arg_for_fun.Name = "arg_for_fun";
        arg_for_fun.Size = new Size(120, 23);
        arg_for_fun.TabIndex = 20;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(6, 93);
        label9.Name = "label9";
        label9.Size = new Size(236, 15);
        label9.TabIndex = 19;
        label9.Text = "Операнд для дополнительного действия: ";
        // 
        // fun
        // 
        fun.Items.AddRange(new object[] { "Декримент ", "Деление", "Инкримент", "Не равно", "Равно", "Умножение" });
        fun.Location = new Point(143, 279);
        fun.Name = "fun";
        fun.Size = new Size(121, 23);
        fun.TabIndex = 18;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(12, 279);
        label8.Name = "label8";
        label8.Size = new Size(125, 15);
        label8.TabIndex = 17;
        label8.Text = "Выбранное действие:";
        // 
        // to_calculate
        // 
        to_calculate.BackColor = SystemColors.ActiveCaptionText;
        to_calculate.ForeColor = SystemColors.ButtonFace;
        to_calculate.Location = new Point(7, 110);
        to_calculate.Name = "to_calculate";
        to_calculate.Size = new Size(131, 23);
        to_calculate.TabIndex = 14;
        to_calculate.Text = "Вычеслить число";
        to_calculate.UseVisualStyleBackColor = false;
        to_calculate.Click += to_calculate_Click;
        // 
        // y_number
        // 
        y_number.Location = new Point(143, 50);
        y_number.Name = "y_number";
        y_number.ReadOnly = true;
        y_number.Size = new Size(120, 23);
        y_number.TabIndex = 13;
        // 
        // x_number
        // 
        x_number.Location = new Point(143, 19);
        x_number.Name = "x_number";
        x_number.ReadOnly = true;
        x_number.Size = new Size(120, 23);
        x_number.TabIndex = 12;
        // 
        // number
        // 
        number.Location = new Point(143, 82);
        number.Name = "number";
        number.ReadOnly = true;
        number.Size = new Size(120, 23);
        number.TabIndex = 11;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(7, 81);
        label7.Name = "label7";
        label7.Size = new Size(73, 15);
        label7.TabIndex = 10;
        label7.Text = "Общий вид:";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(6, 50);
        label6.Name = "label6";
        label6.Size = new Size(89, 15);
        label6.TabIndex = 8;
        label6.Text = "Мнимая часть:";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(6, 19);
        label5.Name = "label5";
        label5.Size = new Size(131, 15);
        label5.TabIndex = 7;
        label5.Text = "Действительная часть:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(6, 19);
        label2.Name = "label2";
        label2.Size = new Size(89, 15);
        label2.TabIndex = 2;
        label2.Text = "Модуль числа:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(6, 53);
        label1.Name = "label1";
        label1.Size = new Size(99, 15);
        label1.TabIndex = 1;
        label1.Text = "Аргумент числа:";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(modl);
        groupBox2.Controls.Add(arg_for_fun);
        groupBox2.Controls.Add(org);
        groupBox2.Controls.Add(label9);
        groupBox2.Controls.Add(label1);
        groupBox2.Enabled = false;
        groupBox2.Location = new Point(12, 120);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(418, 142);
        groupBox2.TabIndex = 26;
        groupBox2.TabStop = false;
        groupBox2.Text = "Введите:";
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(label5);
        groupBox3.Controls.Add(x_number);
        groupBox3.Controls.Add(label6);
        groupBox3.Controls.Add(y_number);
        groupBox3.Controls.Add(label7);
        groupBox3.Controls.Add(to_calculate);
        groupBox3.Controls.Add(number);
        groupBox3.Location = new Point(12, 308);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(360, 139);
        groupBox3.TabIndex = 27;
        groupBox3.TabStop = false;
        groupBox3.Text = "Вывод:";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaption;
        ClientSize = new Size(484, 461);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Controls.Add(fun);
        Controls.Add(label8);
        MinimumSize = new Size(500, 500);
        Name = "Form1";
        Text = "Буханов Д.Е. группа 3105об. Вариант 12";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)org).EndInit();
        ((System.ComponentModel.ISupportInitialize)modl).EndInit();
        ((System.ComponentModel.ISupportInitialize)arg_for_fun).EndInit();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox groupBox1;
    private RadioButton mode_random_true;
    private RadioButton mode_random_false;
    private NumericUpDown org;
    private NumericUpDown modl;
    private NumericUpDown arg_for_fun;
    private Label label9;
    private ComboBox fun;
    private Label label8;
    private Button to_calculate;
    private TextBox y_number;
    private TextBox x_number;
    private TextBox number;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label2;
    private Label label1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
}
