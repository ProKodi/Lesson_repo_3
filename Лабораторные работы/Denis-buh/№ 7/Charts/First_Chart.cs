



class First_Chart: Chart{
    protected double g = 0; 
    public void arg(double g){this.g = g;}

    protected (double, double) function(double x){
        double temp = Math.Sqrt(Math.Pow(x, 3) * (x - this.g)); 
        return (-temp, temp); 
    }

    public override void Draw_Chart(ref Graphics obj){
        Pen pen = new Pen(Color.Black, 1);
        // len x = 400
        this.Draw_Field(ref obj); 
        //obj.DrawLine(pen, 200, 300, 400, 300);
        //obj.DrawLine(pen, 300, 200, 300, 400);
        for(int x = -x_radius / k; x < x_radius / k; x += 1){
            (double, double) res = function(x); 
            (double, double) res1 = function(x+1); 
            int x1 = (x * k) + this.x_0; int x2 = ((x + 1) * k) + this.x_0; 
            int y11 = (int)(this.y_0 - res.Item1); int y12 = (int)(this.y_0 - res1.Item1); 
            obj.DrawLine(pen, x1, y11, x2, y12);

            int y21 = (int)(this.y_0 - res.Item2); int y22 = (int)(this.y_0 - res1.Item2); 

            obj.DrawLine(pen, x1, y21, x2, y22);
            
            //obj.DrawLine(pen, x + this.x_0, (int)(this.y_0 - res), x+1 + this.x_0, (int)(this.y_0 - res1));


            //(double, double) res = function(x); 
            //(double, double) res1 = function(x+1); 
            //obj.DrawLine(pen, x, (int)(res.Item1 + this.y_0), x+1, (int)(res1.Item1 + this.y_0));
            //obj.DrawLine(pen, x, (int)(res.Item2 + this.y_0), x+1, (int)(res1.Item2 + this.y_0));
        }
    }
}