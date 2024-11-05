



class Third_Chart: Chart{
    protected double g = 1; 
    public double G{set{this.g = value;}}

    protected (double, double) function(double x){
        double temp = Math.Sqrt(Math.Pow(x, 3) * (x - g)); 
        return (-temp, temp); 
    }

    public override void Draw_Chart(ref Graphics obj){
        this.Draw_Field(ref obj); 
        for(int x = - x_radius / this.kof; x < x_radius / this.kof; x += 1){
            (double, double) res1 = function(x);
            (double, double) res2 = function(x + 1);
            this.Draw_line_on_Chart(ref obj, x, (int)res1.Item1, 
                x + 1, (int)res1.Item2
            ); 
            this.Draw_line_on_Chart(ref obj, x, (int)res2.Item1, 
                x + 1, (int)res2.Item2
            ); 
        }
    }
}