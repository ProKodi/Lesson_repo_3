



// Класс реализующий основное окно
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void to_calculate_Click(object sender, EventArgs e)
    {
        // Считываем модуль и аргумент и передаем это в конструктор класс для комплексных чисел
        Complex obj = new Complex((double)modl.Value, (double)org.Value);
        // Устанавливаем действительную часть
        x_number.Text = Convert.ToString(obj.get_x()); 
        // Устанавливаем комплексную часть
        y_number.Text = Convert.ToString(obj.get_y()); 
        // Устанавливаем общий вид
        number.Text = obj.get(); 
    }
}



static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }    
}