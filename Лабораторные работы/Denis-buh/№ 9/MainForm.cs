



partial class MainForm: Form{
    public MainForm(){
        InitializeComponent();
        Stack_Student.get_obj();
    }

    /// <summary>Добавление данных</summary>
    private void append_item_Click(object sender, EventArgs e){
        Input.InputForm form = new Input.InputForm();
        form.append_function = (Student stude) =>{
            Stack_Student.get_obj().append(stude);
            this.TableTree.Rows.Add(new object[]{stude.Name, stude.Age, 
                    stude.Number_cout, stude.Name_group, stude.Hp
                }
            );
        }; 
        form.ShowDialog(this);
    }

    /// <summary>Удаление данных с таблицы и структуры</summary>
    private void delete_item_Click(object sender, EventArgs e){
        int index = this.TableTree.CurrentCell.RowIndex;
        Stack_Student.get_obj().delete(index);
        this.TableTree.Rows.RemoveAt(index);
        this.TableTree.Refresh();
    }

    private void find_item_Click(object sender, EventArgs e){
        Console.WriteLine("Find item");
        FindForm form = new FindForm();
        form.ShowDialog(this);

        int index = Stack_Student.get_obj().find_item(form.Name_found);
        if(index == -1){
            MessageBox.Show("Обьект не найден", "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        for(int i = 0; i < Stack_Student.get_obj().Count; i += 1){
            this.TableTree.Rows[i].Selected = false;
        }
        this.TableTree.Rows[index].Selected = true;
    }


    private void filtration_item_Click(object sender, EventArgs e){
        Filter form = new Filter();
        form.ShowDialog(this);
        this.TableTree.Rows.Clear();
        if(form.filter){

            string name = form.Name_find.Trim();
            Console.WriteLine($"{{{name}}}");
            if (name != ""){
                Stack<Student> temp = Stack_Student.get_obj().select_name(name);
                while(temp.Count > 0){
                    Student stude = temp.Pop();
                    this.TableTree.Rows.Add(new object[]{stude.Name, stude.Age, 
                        stude.Number_cout, stude.Name_group, stude.Hp
                    });
                }
                return;
            }

            else{
                int age = form.Age_find;
                Stack<Student> temp = Stack_Student.get_obj().select_age(age);
                while(temp.Count > 0){
                    Student stude = temp.Pop();
                    this.TableTree.Rows.Add(new object[]{stude.Name, stude.Age, 
                        stude.Number_cout, stude.Name_group, stude.Hp
                    });
                }
                return;
            }
        }
        
        else{
            Stack<Student> temp = Stack_Student.get_obj().Students;
            while(temp.Count > 0){
                Student stude = temp.Pop();
                this.TableTree.Rows.Add(new object[]{stude.Name, stude.Age, 
                    stude.Number_cout, stude.Name_group, stude.Hp
                });
            }
        }
    }
}