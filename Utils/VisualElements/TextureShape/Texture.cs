using System.Text.Json;
using Raylib_cs;

public abstract class TextureShape : VisualElements
{
    protected string texturePath;
    public TextureShape(string texturePath)
    {
        this.texturePath = texturePath;
    }

   
}