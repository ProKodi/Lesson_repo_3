



public partial class MainWindow : Form{
    public MainWindow(){InitializeComponent();}

    private void show_Patient_Hospital_Click(object sender, EventArgs e){
        List <Human> list = new List<Human>(Exemple.Get_Patient_Hospital());

        Sorted.Sort(list, 0, list.Count-1);
        ShowInform form = new ShowInform();
        foreach (Patient_Hospital i in list){ form.AppendInform(i.ToString());}
        form.ShowDialog(this);
    }

    private void show_Doctor_Click(object sender, EventArgs e){
        List <Human> list = new List<Human>(Exemple.Get_Doctor()); 

        Sorted.Sort(list, 0, list.Count-1);
        ShowInform form = new ShowInform();

        if (this.delete_terapeft.Checked){
            for (int i = 0; i < list.Count; i += 1){
                if (((Doctor)list[i]).Speciality == "Терапевт"){list.RemoveAt(i);}
            }
        }
        foreach (Doctor i in list){ form.AppendInform(i.ToString());}
        form.ShowDialog(this);
    }

    private void show_Patient_Polyclinics_Click(object sender, EventArgs e){
        List <Human> list = new List<Human>(Exemple.Get_Patient_Polyclinics());
        Sorted.Sort(list, 0, list.Count-1);

        ShowInform form = new ShowInform();
        foreach (Patient_Polyclinics i in list){ 
            i.GetInform += NewClass.GetInform;
            form.AppendInform(i.ToString());
        }
        form.ShowDialog(this);
    }
}

