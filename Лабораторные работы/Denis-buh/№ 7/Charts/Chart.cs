



interface IChart{
    /// <summary>Метод для задания нулевой точки</summary>
    public void Set_point0(int x_0, int y_0); 

    /// <summary>>Метод для задания максимального растояние от центра</summary>
    public void Set_radius(int x_radius, int y_radius);


    /// <summary>Рисование линии на графике</summary>
    public void Draw_line_on_Chart(ref Graphics obj, int x0, int y0, int x1, int y1); 

    /// <summary>Отрисовка графика</summary>
    public void Draw_Chart(ref Graphics obj); 
}


abstract class Chart: IChart{
    /// <summary>Коофицент иасштабирования графика</summary>
    protected int kof = 1;
    /// <summary>Сетер гетер коофицента мастабирования</summary>
    public int Kof{
        get{return this.kof;}
        set{
            if(value < 1){throw new ArgumentOutOfRangeException("Поданы не верные значения");}
            this.kof = value;
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
    protected Color color; 

    /// <summary>>Метод для задания цвета</summary>
    public Color Col{set{this.color = value;}}

    public void Draw_Field(ref Graphics obj){
        Pen pen = new Pen(Color.Red, 4);
        obj.DrawEllipse(pen, this.x_0 - 1, this.y_0 - 1, 1, 1);
        pen = new Pen(Color.Black, 1);
        for(int y = 0; y <= this.y_radius; y += this.kof){
            obj.DrawLine(pen, this.x_0 - this.x_radius, this.y_0 - y, this.x_0 + this.x_radius, this.y_0 - y);
            obj.DrawLine(pen, this.x_0 - this.x_radius, this.y_0 + y, this.x_0 + this.x_radius, this.y_0 + y);
        }
        for(int x = 0; x <= this.x_radius; x += this.kof){
            obj.DrawLine(pen, this.x_0 - x, this.y_0 - this.y_radius, this.x_0 - x, this.y_0 + this.y_radius);
            obj.DrawLine(pen, this.x_0 + x, this.y_0 - this.y_radius, this.x_0 + x, this.y_0 + this.y_radius);
        }
    }

    public void Draw_line_on_Chart(ref Graphics obj, int x0, int y0, int x1, int y1){
        if (Math.Abs(x0 * this.kof) > this.x_radius){return;}
        if (Math.Abs(x1 * this.kof) > this.x_radius){return;}
        if (Math.Abs(y0 * this.kof) > this.y_radius){return;}
        if (Math.Abs(y1 * this.kof) > this.y_radius){return;}
        Pen pen = new Pen(this.color, 2);
        obj.DrawLine(pen, (x0 * this.kof) + this.x_0, this.y_0 - (y0 * this.kof), 
            (x1 * this.kof) + this.x_0, this.y_0 - (y1 * this.kof)
        );
    }
    
    public abstract void Draw_Chart(ref Graphics obj); 
}