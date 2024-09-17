



// Класс реализующий основное окно
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void to_calculate_Click(object sender, EventArgs e)
    {
        double? tem_modl = null; 
        double? tem_org = null; 
        try{
            tem_modl = Convert.ToDouble(modl.Text);
        }
        catch (FormatException){
            MessageBox.Show("В числе (модуле) не должно быть букв или вы не ввели число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception){
            MessageBox.Show("Произошла не известная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        try{
            tem_org = Convert.ToDouble(org.Text); 
        }
        catch (FormatException){
            MessageBox.Show("В числе (аргументе) не должно быть букв или вы не ввели число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception){
            MessageBox.Show("Произошла не известная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        if ((tem_modl != null) &&  (tem_org != null)){
            // Считываем модуль и аргумент и передаем это в конструктор класс для комплексных чисел
            Complex obj = new Complex((double)tem_modl, (double)tem_org);
            // Устанавливаем действительную часть
            x_number.Text = Convert.ToString(obj.get_x()); 
            // Устанавливаем комплексную часть
            y_number.Text = Convert.ToString(obj.get_y()); 
            // Устанавливаем общий вид
            number.Text = obj.get(); 
        }
        
    }
}



public partial class Form2 : Form{
    private void mode_random_true_CheckedChanged(object sender, EventArgs e)
    {
        groupBox2.Enabled = false;
    }

    private void mode_random_false_CheckedChanged(object sender, EventArgs e)
    {
        groupBox2.Enabled = true;
    }

    private void to_calculate_Click(object sender, EventArgs e)
    {
        Console.WriteLine($"modl = {modl.Value}"); 
        Console.WriteLine($"org = {org.Value}"); 
        Console.WriteLine($"arg_for_fun = {arg_for_fun.Value}"); 
        

        // ��������� ������ � �������� � �������� ��� � ����������� ����� ��� ����������� �����
        //Complex obj = new Complex((double)modl.Text, (double)org.Text);
        // ������������� �������������� �����
        //x_number.Text = Convert.ToString(obj.get_x());
        // ������������� ����������� �����
        //y_number.Text = Convert.ToString(obj.get_y());
        // ������������� ����� ���
        //number.Text = obj.get();
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