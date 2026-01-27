using Raylib_cs;

public class TextureRectangle : TextureShape
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

}