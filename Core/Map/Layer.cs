using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Raylib_cs;

public class Layer
{
    public int Width { get; }
    public int Height { get; }
    public string LayerName { get; set; }
    public LayerType LayerType { get; }

    public AbstractObject[,] _layerMetrix{ get; set; }

    public Layer(LayerType layerType, string layerName,AbstractObject[,] layerMetix)
    {

        this.LayerType = layerType;
        this.LayerName = layerName;

        _layerMetrix = layerMetix;
        this.Width = layerMetix.GetLength(0);
        this.Height = layerMetix.GetLength(1);

    }

    public bool CompereTypes(int x, int y, Type ObecjtType)
    {
        if (BoundsCheck(x, y))
        {
            return false;
        }

        if (_layerMetrix[x, y] is not null)
        {
            if (_layerMetrix[x, y].GetType() == ObecjtType)
            {
                return true;
            }
        }

        return false;
    }

    public bool GetObjectType(int x, int y, out Type? ObjectType)
    {
        if (BoundsCheck(x, y) == false)
        {
            ObjectType = null;
            return false;
        }

        if (_layerMetrix[x, y] is not null)
        {
            ObjectType = _layerMetrix[x, y].GetType();
            return true;
        }

        ObjectType = null;

        return false;
    }

    private bool BoundsCheck(int x, int y)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            return true;
        }

        return false;
    }

    private LayerType GetLayerType()
    {
        return LayerType;
    }

    public void Draw()
    {
        for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
                if (_layerMetrix[x, y] is not null)
                {
                    if (_layerMetrix[x, y] is IdrawObjcet drawObject)
                    {

                        drawObject.Draw(x, y);

                    }

                }
        
        
    }

    public string JsonBuilder()
    {

        var options = new JsonWriterOptions
        {
            Indented = true
        };

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream,options);

        writer.WriteStartObject();
        writer.WriteString("layerType", LayerType.ToString());
        writer.WriteString("LayerName", LayerName);


      
        for (int x = 0; x < Width; x++)
       {
            writer.WriteStartObject("ColumnObject");
            writer.WriteStartArray($"Column_{x}");
            for (int y = 0; y < Height; y++)
            {
                if(_layerMetrix[x,y] is not null)
                {
                  writer.WriteStringValue(PolymorphicJson.AbstractObjectBuilder(_layerMetrix[x,y]));
                }
                else
                {
                   writer.WriteStringValue("null");
                }
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
       }
       
        writer.WriteEndObject();
        writer.Flush();
        return Encoding.UTF8.GetString(stream.ToArray());
    }


     public static Layer JsonBuilder(string jsonString) // relly need to clean this up. To much AI slop fix.
     {

      throw new NotImplementedException();

     }
}


