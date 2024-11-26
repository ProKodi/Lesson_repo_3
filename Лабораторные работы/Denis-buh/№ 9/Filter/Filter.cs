



partial class Filter : Form{
    public Filter(){
        InitializeComponent();
    }

    public bool filter{get{return this.made_sort.Checked;}}

    public string Name_find{get{return this.name_find.Text;}}
    public int Age_find{get{return (int)this.age_find.Value;}}
    
}

