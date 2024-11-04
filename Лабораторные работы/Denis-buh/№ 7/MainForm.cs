



partial class MainForm : Form{
    public MainForm(){InitializeComponent();}

    // Завершение работы
    private void Exit_Click(object sender, EventArgs e){Application.Exit();}

    // Рисование на форме
    private void MainForm_Paint(object sender, PaintEventArgs e){
        // Console.WriteLine(2); 
        // draw form 1, 2, 3, 4

        Graphics g = e.Graphics; //использование графическ. объекта
        First_Chart graf = new First_Chart(); 
        graf.Set_point0(300, 300); 
        graf.Set_radius(100, 100); 
        graf.K(10); 
        //graf.Set_min_point(0, 0); 
        //graf.Set_max_point(400, 400); 
        graf.arg(1); 
        graf.Draw_Chart(ref g); 
        /*Pen pen = new Pen(Color.Black, 1);
        g.DrawLine(pen, 0, 25, 10, 31);
        g.DrawLine(pen, 0, 25, 8, 900);*/
    }

    // Информация о графиках
    private void inform_graphics_Click(object sender, EventArgs e){

    }

    // Очистить поля
    private void clean_Click(object sender, EventArgs e){

    }

    // Перестроить графики
    private void build_graphics_Click(object sender, EventArgs e){

    }

    // Параметры графиков
    private void settings_graphics_Click(object sender, EventArgs e){

    }
}

