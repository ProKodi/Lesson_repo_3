



partial class MainForm : Form{
    public MainForm(){InitializeComponent();}

    /// <summary>Метод для рисования графиков</summary>
    protected void paint_charts(PaintEventArgs e){
        Graphics g = e.Graphics;
            int height = DisplayRectangle.Height; // Высота
            int width = DisplayRectangle.Width; // Ширина

            {
                (int, int) x =  (0, width / 2); 
                (int, int) y =  (50, (height - 50) / 2); 
                Console.WriteLine("first");
                Console.WriteLine($"x = [{x.Item1}, {x.Item2}]; y = [{y.Item1}, {y.Item2}]");
                Console.WriteLine($"x = {(x.Item1 + x.Item2) / 2} y = {(y.Item1 + y.Item2) / 2}");
                Console.WriteLine($"x = {(x.Item2 - x.Item1) / 2} y = {(y.Item2 - y.Item1) / 2}");
                First_Chart graf1 = new First_Chart(); 
                graf1.Set_point0((x.Item1 + x.Item2) / 2, (y.Item1 + y.Item2) / 2); 
                graf1.Set_radius((x.Item2 - x.Item1) / 2, (y.Item2 - y.Item1) / 2); 
                graf1.K = 10; 
                graf1.arg(1); 
                graf1.Draw_Chart(ref g); 
            }
            

           /* Pen pen = new Pen(Color.Yellow, 1);
            for(int x = 0; x < width / 2; x += 1){
                g.DrawLine(pen, x, 50, x, height / 2);
            }

            Console.WriteLine("second");
            Console.WriteLine($"x = [{width / 2}, {width }]; y = [{50}, {(height - 50) / 2}]");
            pen = new Pen(Color.Black, 1);
            for(int x = width / 2; x < width; x += 1){
                g.DrawLine(pen, x, 50, x, height / 2);
            }

            Console.WriteLine("third");
            Console.WriteLine($"x = [{0}, {width / 2}]; y = [{height / 2}, {height}]");
            pen = new Pen(Color.Green, 1);
            for(int x = 0; x < width / 2; x += 1){
                g.DrawLine(pen, x, height / 2, x, height);
            }

            Console.WriteLine("fourth");
            Console.WriteLine($"x = [{width / 2}, {width }]; y = [{height / 2}, {height}]");
            pen = new Pen(Color.Red, 1);
            for(int x = width / 2; x < width; x += 1){
                g.DrawLine(pen, x, height / 2, x, height);
            }*/



    }

    // Завершение работы
    private void Exit_Click(object sender, EventArgs e){Application.Exit();}

    // Рисование на форме
    private void MainForm_Paint(object sender, PaintEventArgs e){
        this.paint_charts(e);
        /*Graphics g = e.Graphics; //использование графическ. объекта
        First_Chart graf = new First_Chart(); 
        graf.Set_point0(300, 300); 
        graf.Set_radius(100, 100); 
        graf.K = 10; 
        //graf.Set_min_point(0, 0); 
        //graf.Set_max_point(400, 400); 
        graf.arg(1); 
        graf.Draw_Chart(ref g); */
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

