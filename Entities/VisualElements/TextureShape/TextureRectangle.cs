using Raylib_cs;
using System.Text.Json;
using System.Text;


public class TextureRectangle : TextureShape, IJson
{

    protected int width;
    protected int height;

    private Texture2D texture;
    
    public TextureRectangle(string texturePath, int width, int height) 
    : base(texturePath)
    {
        this.width = width;
        this.height = height;

        var tempImage = Raylib.LoadImage(texturePath);
        Raylib.ImageResize(ref tempImage, width, height);
        texture = Raylib.LoadTextureFromImage(tempImage);
        Raylib.UnloadImage(tempImage);
    }

    public override void Draw(int x, int y)
    {
         
         Raylib.DrawTexture(texture, x * 100,y * 100,Color.White);

    }

    public string JsonBuilder()
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        writer.WriteStartObject();
        writer.WriteString("VisualElementType",this.GetType().Name);
        writer.WriteString("TexturePath", texturePath);
        writer.WriteNumber("Width", width);
        writer.WriteNumber("Height", height);
        writer.WriteEndObject();
        writer.Flush();
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public string GetTexturePath()
    {
        return this.texturePath;
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