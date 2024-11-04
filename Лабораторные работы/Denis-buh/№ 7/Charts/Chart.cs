



interface IChart{
    /// <summary>Метод для задания нулевой точки</summary>
    public void Set_point0(int x_0, int y_0); 

    /// <summary>>Метод для задания максимального растояние от центра</summary>
    public void Set_radius(int x_radius, int y_radius);

    /// <summary>Отрисовка графика</summary>
    public void Draw_Chart(ref Graphics obj); 
}


abstract class Chart: IChart{
    /// <summary>Коофицент иасштабирования графика</summary>
    protected int k = 1;
    /// <summary>Сетер гетер коофицента мастабирования</summary>
    public int K{
        get{return this.k;}
        set{
            if(value < 1){throw new ArgumentOutOfRangeException("Поданы не верные значения");}
            this.k = value;
        }
    }

    /// <summary>X нулевой точки</summary>
    protected int x_0 = 0;
    /// <summary>Y нулевой точки</summary>
    protected int y_0 = 0; 
    public void Set_point0(int x_0, int y_0){
        this.x_0 = x_0; 
        this.y_0 = y_0; 
    }

    /// <summary>Максимальное растояние от центра графика по X</summary>
    protected int x_radius = 0;
    /// <summary>Максимальное растояние от центра графика по Y</summary>
    protected int y_radius = 0; 
    public void Set_radius(int x_radius, int y_radius){
        this.x_radius = x_radius; 
        this.y_radius = y_radius; 
    }

    public void Draw_Field(ref Graphics obj){
        Pen pen = new Pen(Color.Red, 4);
        obj.DrawEllipse(pen, this.x_0 - 1, this.y_0 - 1, 1, 1);
        pen = new Pen(Color.Black, 1);
        for(int y = 0; y <= this.y_radius; y += this.k){
            obj.DrawLine(pen, this.x_0 - this.x_radius, this.y_0 - y, this.x_0 + this.x_radius, this.y_0 - y);
            obj.DrawLine(pen, this.x_0 - this.x_radius, this.y_0 + y, this.x_0 + this.x_radius, this.y_0 + y);
        }
        for(int x = 0; x <= this.x_radius; x += this.k){
            obj.DrawLine(pen, this.x_0 - x, this.y_0 - this.y_radius, this.x_0 - x, this.y_0 + this.y_radius);
            obj.DrawLine(pen, this.x_0 + x, this.y_0 - this.y_radius, this.x_0 + x, this.y_0 + this.y_radius);
        }
    }

    public abstract void Draw_Chart(ref Graphics obj); 
}