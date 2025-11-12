using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connection_lab{
    public partial class EditingAndViewingForm : Form{
        List<string> list_Spet = [];

        List<(long, Strudent)> original_data = [];

        public EditingAndViewingForm()
        {
            InitializeComponent();

        }

        public async Task Init(){
            this.list_Spet = await DataBase.SinglDataBase.GetNameSpetialitest();
            
            this.MainDataGrid.Rows.Clear();
            
            foreach (var i in this.list_Spet){ this.NameSpecialty.Items.Add(i); }

            this.original_data = await DataBase.SinglDataBase.GetStudent();

            foreach ((long id, Strudent st) in this.original_data){
                this.MainDataGrid.Rows.Add(
                    st.Name, st.Sex, st.Parents,
                    st.Address, st.PhoneNumber, st.passportData,
                    st.Group, st.Birthday, st.DateReceipt,
                    st.IsFullTime, st.NumberRecordBook, st.NuberCourse,
                    st.NameSpecialty
                );
            }

        }

        private void AddDataButton_Click(object sender, EventArgs e){
            this.MainDataGrid.Rows.Add();
        }

        private void DeleteDataButton_Click(object sender, EventArgs e){
            // Проверяем, есть ли выбранная строка
            if (this.MainDataGrid.CurrentRow != null && !this.MainDataGrid.CurrentRow.IsNewRow){
                // Удаляем выбранную строку
                this.MainDataGrid.Rows.Remove(this.MainDataGrid.CurrentRow);
            }
            else{
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private  void UpdateDataButton_Click(object sender, EventArgs e)
        {
            


            



        }
    }
}
