



class First_Chart: Chart{
    protected double k = 1; 
    public double K{set{this.k = value;}}

    protected double b = 0; 
    public double B{set{this.b = value;}}

    protected double function(double x){
        return (this.k * x) + this.b;
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