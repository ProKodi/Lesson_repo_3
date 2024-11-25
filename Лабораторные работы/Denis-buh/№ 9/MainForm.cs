



// delegate void Change_Function(Student stude); 



partial class MainForm: Form{
    public MainForm(){
        InitializeComponent();
    }

    /// <summary>Добавление данных</summary>
    public void append(Student stude){
        this.TableTree.Rows.Add(new object[]{stude.Name, stude.Age, 
            stude.Number_cout, stude.Name_group, stude.Hp
            }
        );
    }



    private void filtration_item_Click(object sender, EventArgs e){
        Console.WriteLine("Filtration colection");
    }

    private void append_item_Click(object sender, EventArgs e){
        Console.WriteLine("Append item");
        Input.InputForm form = new Input.InputForm();
        form.append_function = this.append; 
        form.ShowDialog(this);
    }

    private void delete_item_Click(object sender, EventArgs e){
        Console.WriteLine("Delete item");
        Console.WriteLine(this.TableTree.CurrentCell.RowIndex);
    }

    private void find_item_Click(object sender, EventArgs e){
        Console.WriteLine("Find item");
    }
}