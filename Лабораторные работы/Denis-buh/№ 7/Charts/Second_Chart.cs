



class Second_Chart: Chart{
    protected double a = 1; 
    public double A{set{this.a = value;}}

    protected double function(double x){
        double temp = x / this.a;
        return (this.a / 2) * (Math.Pow(Math.E, temp) + Math.Pow(Math.E, -temp)); 
    }

    public override void Draw_Chart(ref Graphics obj){
        this.Draw_Field(ref obj); 
        for(int x = - x_radius / this.kof; x < x_radius / this.kof; x += 1){
            this.Draw_line_on_Chart(ref obj, x, (int)function(x), 
                x + 1, (int)function(x+1)
            ); 
        }
    }
}