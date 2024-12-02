using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp5.InputFile
{
    public partial class InputFile : Form{
        public InputFile(){
            InitializeComponent();
        }

        private void save_file_Click(object sender, EventArgs e){
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовый файл|*.txt";
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.Cancel) { return; }
            // Путь к сохраняемому файлу
            textBox1.Text = saveFileDialog1.FileName;
        }
    }
}
