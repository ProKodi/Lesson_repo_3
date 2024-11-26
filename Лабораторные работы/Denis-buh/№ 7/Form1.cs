using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


delegate void Fun_print();


public partial class Form1 : Form{
    Fields new_fild; 
    bool flag = false;

    public Form1()
    {
        InitializeComponent();
        new_fild = new Fields(900, 900); 
    }

    private void NewSize(object sender, System.EventArgs e) // Метод вызывается при конце редактирования размера формы
    {
        Console.WriteLine(6767);
        flag = false;
        this.Refresh(); 
    }


    private void Form1_Load(object sender, EventArgs e){
    }




    private void Form1_Paint(object sender, PaintEventArgs e){
        if(flag){return;}
        flag = true;

        Graphics g = e.Graphics;
        new_fild.Show(ref g); 

        double step = 0.00001; 

        Fun_print chart1 = delegate(){
            Point zero = new_fild[0].Zero;
            First_Chart chart = new First_Chart(2);
            for(double x = -zero.X; x < zero.X; x += step){
                (double, double) res = chart.function(x);
                (double, double) res1 = chart.function(x + step);
                
                try{
                    FPoint st = new FPoint(x, res.Item1);
                    FPoint en = new FPoint(x + step, res1.Item1);
                    new_fild[0].DrawLine(ref g, st, en, Color.DarkBlue);
                    st = new FPoint(x, res.Item2);
                    en = new FPoint(x + step, res1.Item2);
                    new_fild[0].DrawLine(ref g, st, en, Color.DarkBlue);
                }
                catch(Exception){}
            }
        };

        Fun_print chart2 = delegate(){
            Point zero = new_fild[1].Zero;
            Second_Chart chart = new Second_Chart(2);
            for(double x = -zero.X; x < zero.X; x += step){
                try{
                    FPoint st = new FPoint(x, chart.function(x));
                    FPoint en = new FPoint(x + step, chart.function(x + step));
                    new_fild[1].DrawLine(ref g, st, en, Color.DarkGreen);
                }
                catch(Exception){}
            }
        };

        Fun_print chart3 = delegate(){
            Point zero = new_fild[2].Zero;
            Third_Chart chart = new Third_Chart(2, 3);
            for(double x = -zero.X; x < zero.X; x += step){
                try{
                    FPoint st = new FPoint(x, chart.function(x));
                    FPoint en = new FPoint(x + step, chart.function(x + step));
                    new_fild[2].DrawLine(ref g, st, en, Color.Pink);
                }
                catch(Exception){}
            }
        };

        Fun_print chart4 = delegate(){
            Point zero = new_fild[3].Zero;
            Fourth_Chart chart = new Fourth_Chart(2);
            for(double x = -zero.X; x < zero.X; x += step){
                try{
                    (double, double) res = chart.function(x);
                    (double, double) res1 = chart.function(x + step);
                    FPoint st = new FPoint(x, res.Item1);
                    FPoint en = new FPoint(x + step, res1.Item1);
                    new_fild[3].DrawLine(ref g, st, en, Color.DarkRed);

                    st = new FPoint(x, res.Item2);
                    en = new FPoint(x + step, res1.Item2);
                    new_fild[3].DrawLine(ref g, st, en, Color.DarkRed);
                }
                catch(Exception){}
            }
        };


        Thread myThread1 = new Thread(()=>{chart1();}); 
        Thread myThread2 = new Thread(()=>{chart2();}); 
        Thread myThread3 = new Thread(()=>{chart3();});
        Thread myThread4 = new Thread(()=>{chart4();}); 
        myThread1.Start(); 
        myThread2.Start(); 
        myThread3.Start(); 
        myThread4.Start(); 

        myThread1.Join();
        myThread2.Join();
        myThread3.Join();
        myThread4.Join();



    }
}
