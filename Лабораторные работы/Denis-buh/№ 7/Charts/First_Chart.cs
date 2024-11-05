



class First_Chart: Chart{
    protected double g = 0; 
    public void arg(double g){this.g = g;}

    protected double function(double x){
        return (1 * x) + 0;
    }

    public override void Draw_Chart(ref Graphics obj){
        Pen pen = new Pen(Color.Black, 1);
        this.Draw_Field(ref obj); 

        for(int x = -x_radius; x < x_radius; x += k){
            double res = function(x); 
            if (Math.Abs(res) > this.y_radius){continue;}
            int x1 = x  + this.x_0; 

            double res1 = function(x+k); 

            if (Math.Abs(res1) > this.y_radius){continue;}
            int x2 = (x + k) + this.x_0; 
            obj.DrawLine(pen, x1, (int)(this.y_0 - res), x2, (int)(this.y_0 - res1));
        }
    }
}