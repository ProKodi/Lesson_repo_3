



class Complex{
    protected double modl; // модуль (длина вектора)
    // modl = (x^2 + y^2) ^ 0.5
    // modl^2 = x^2 + y^2
    protected double org; // аргумент (угол к оси x)
    // cos(org) = x / modl // x - дейст. часть = cos(org) * modl
    // sin(org) = y / modl // y - мним. часть = sin(org) * modl

    public Complex(){}

    public Complex(double modl){
        this.modl = modl; 
    }

    public Complex(double modl, double org){
        this.modl = modl; 
        this.org = org; 
    }


    public void input(){
        Console.WriteLine("Введите информацию");
        Console.Write("Введите модуль");
        modl = Convert.ToDouble(Console.ReadLine()); 

        Console.Write("Введите аргумент");
        org = Convert.ToDouble(Console.ReadLine()); 
    }

    // Гетер для действительной части
    public double get_x(){
        return Math.Cos((this.org * Math.PI) / 180) * modl; 
    }

    // Гетер для мнимой части
    public double get_y(){
        return Math.Sin((this.org * Math.PI) / 180) * modl; 
    }

    // Вывод в общем виде
    public string get(){
        double x = this.get_x();
        if (x < 0.000000001){x = 0;}
        double y = this.get_y();
        if (y < 0.000000001){y = 0;}

        return $"{x} + {y} * i"; 
    }
}



class Program{
    public static void Main(){
        // Оформим ввод
        Console.WriteLine("Введите информацию");
        Console.Write("Введите модуль");
        double modl = Convert.ToDouble(Console.ReadLine()); 

        Console.Write("Введите аргумент");
        double org = Convert.ToDouble(Console.ReadLine()); 

        Complex obj = new Complex(modl, org);

        // Вывод
        Console.WriteLine($"Действительная часть = {obj.get_x()}");
        Console.WriteLine($"Мнимая часть = {obj.get_y()}");
        Console.WriteLine($"Общий вид = {obj.get()}");
    }
}