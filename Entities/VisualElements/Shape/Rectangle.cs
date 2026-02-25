using System.Drawing;
using System.Text;
using System.Text.Json;
using Raylib_cs;

public class Rectangle : Shape, IJson{
    
    private static Rectangle? SingletonInstance = null;
    protected int width;
    protected int height;
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

    public string JsonBuilder()
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        writer.WriteStartObject();
        writer.WriteString("VisualElementType",this.GetType().Name);
        writer.WriteNumber("Color", Raylib.ColorToInt(Color));
        writer.WriteNumber("Width", width);
        writer.WriteNumber("Height", height);
        writer.WriteEndObject();
        writer.Flush();
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public Raylib_cs.Color GetColor()
    {
        return this.Color;
    }

    public int GetWidth()
    {
        return this.width;
    }

    public int GetHeight()
    {
        return this.height;
    }
}