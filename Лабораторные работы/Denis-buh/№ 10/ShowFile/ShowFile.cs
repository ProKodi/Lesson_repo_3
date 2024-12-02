using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5.ShowFile{
    public partial class ShowFile : Form{
        public ShowFile(){
            InitializeComponent();
        }

        public void append_text(string text){
            text_before.Text = "хуй";
            text_after.Text = "хуй измененый";
        }
    }
}
