



class Student{
    /// <summary>ФИО</summary>
    protected string name = "";
    public string Name{
        get{return this.name;}
        set{
            if(value == ""){throw new ArgumentException();}
            this.name = value;
        }
    }

    /// <summary>Количество лет</summary>
    protected int age;
    public int Age{
        get{return this.age;}
        set{
            if(value <= 0){throw new ArgumentException();}
            this.age = value;
        }
    }

    /// <summary>Номер курса</summary>
    protected int number_cout;
    public int Number_cout{
        get{return this.number_cout;}
        set{
            if(value < 1){throw new ArgumentException();}
            this.number_cout = value;
        }
    }

    /// <summary>Номер группы</summary>
    protected string name_group = "";
    public string Name_group{
        get{return this.name_group;}
        set{
            if(value == ""){throw new ArgumentException();}
            this.name_group = value;
        }
    }

    /// <summary>Процент hp</summary>
    protected int hp;
    public int Hp{
        get{return this.hp;}
        set{this.hp = value;}
    }

    public Student(string name, int age, int number_cout, string name_group, int hp){
        this.Name = name;
        this.Age = age;
        this.Number_cout = number_cout;
        this.Name_group = name_group;
        this.Hp = hp;
    }
}