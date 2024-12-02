using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InputFile_Click(object sender, EventArgs e){
            InputFile.InputFile input_file = new InputFile.InputFile();
            input_file.ShowDialog();
        }

        private void PrintFile_Click(object sender, EventArgs e){
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовый файл|*.txt";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.Cancel) { return;}
            ShowFile.ShowFile input_file = new ShowFile.ShowFile();
            input_file.append_text("fc");
            input_file.ShowDialog();
        }
    }
}
