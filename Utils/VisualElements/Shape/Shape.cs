using System.Drawing;

public abstract class Shape : VisualElements
{
    protected Raylib_cs.Color Color;
    
    public Shape(Raylib_cs.Color color) 
    {
        this.Color = color;
    }

}