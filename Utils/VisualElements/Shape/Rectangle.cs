using System.Drawing;
using Raylib_cs;

public class Rectangle : Shape 
{
    protected int width;
    protected int height;

    public Rectangle rectangle{get;}
    public Rectangle(Raylib_cs.Color color, int width, int height) 
    : base(color)
    {
        this.width = width;
        this.height = height;

    }

    public override void Draw(int x, int y)
    {
        
        Raylib.DrawRectangle(x * 100,y * 100,width,height,Color);

    }
  

}