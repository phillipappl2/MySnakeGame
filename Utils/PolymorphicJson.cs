using System.Text;
using System.Text.Json;
using Raylib_cs;

static class PolymorphicJson
{

    public static VisualElements VisualElementBuilder(string jsonString)
    {
        
        var objects = JsonDocument.Parse(jsonString);
        string type = objects.RootElement.GetProperty("VisualElementType").GetString() ?? "";

        switch (type)
        {
            case "Rectangle"
                :{
                    var colorInt = objects.RootElement.GetProperty("Color").GetInt32();
                    var width = objects.RootElement.GetProperty("Width").GetInt32();
                    var height = objects.RootElement.GetProperty("Height").GetInt32();
                    return new Rectangle(Raylib.GetColor((uint)colorInt), width, height);
                }
                

            case "TextureRectangle":
                {
                    var texturePath = objects.RootElement.GetProperty("TexturePath").GetString() ?? "";
                    var width = objects.RootElement.GetProperty("Width").GetInt32();
                    var height = objects.RootElement.GetProperty("Height").GetInt32();
                    return new TextureRectangle(texturePath, width, height);
                }
            default:
                throw new Exception("Unknown type");
            
            
        }

    }

    public static string VisualElementBuilder(VisualElements obj)
    {
        
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        switch (obj)
        {
            case Rectangle rectangle:
            {
                writer.WriteStartObject();
                writer.WriteString("VisualElementType", "Rectangle");
                writer.WriteNumber("Color", Raylib.ColorToInt(rectangle.GetColor()));
                writer.WriteNumber("Width", rectangle.GetWidth());
                writer.WriteNumber("Height", rectangle.GetHeight());
                writer.WriteEndObject();
                writer.Flush();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            case TextureRectangle textureRectangle:
            {
                writer.WriteStartObject();
                writer.WriteString("VisualElementType", "TextureRectangle");
                writer.WriteString("TexturePath", textureRectangle.GetTexturePath());
                writer.WriteNumber("Width", textureRectangle.GetWidth());
                writer.WriteNumber("Height", textureRectangle.GetHeight());
                writer.WriteEndObject();
                writer.Flush();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
           
                
            // Add more cases as needed
            default:
                throw new Exception("Unknown type");
        }

         
    }




    public static AbstractObject AbstractObjectBuilder(string jsonString)
    {
        
        var objects = JsonDocument.Parse(jsonString);
        string type = objects.RootElement.GetProperty("AbstractObjectType").GetString() ?? "";  
        
        switch (type)
        {
            case "Wall"
                :{
                    var visualElementJson = objects.RootElement.GetProperty("VisualElements").GetString() ?? "";
                    var visualElement = VisualElementBuilder(visualElementJson);
                    return new Wall(visualElement);
                }
            case "Door"
                :{
                    var visualElementJson = objects.RootElement.GetProperty("VisualElements").GetString() ?? "";
                    bool IsOpen = objects.RootElement.GetProperty("IsOpen").GetBoolean();
                    var visualElement = VisualElementBuilder(visualElementJson);

                    return new Door(visualElement, IsOpen);
                }
            default:
                throw new Exception("Unknown type");
            
        }

    }

     public static string AbstractObjectBuilder(AbstractObject obj)
     {
        
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        switch (obj)
        {
            case Wall wall:
            {
                writer.WriteStartObject();
                writer.WriteString("AbstractObjectType", "Wall");
                writer.WriteString("VisualElements", VisualElementBuilder(wall.GetVisualElement()));
                writer.WriteEndObject();
                writer.Flush();
                return Encoding.UTF8.GetString(stream.ToArray());
             
            }
                
            // Add more cases as needed
            default:
                throw new Exception("Unknown type");
        }

         
     }

   
    
}