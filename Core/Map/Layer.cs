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


         writer.WriteStartObject("ColumnObject");
        for (int x = 0; x < Width; x++)
       {
         
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
          
       }
         writer.WriteEndObject();
       
        writer.WriteEndObject();
        writer.Flush();
        return Encoding.UTF8.GetString(stream.ToArray());
    }


     public static Layer JsonBuilder(string jsonString) // relly need to clean this up. To much AI slop fix.
     {
        var objects = JsonDocument.Parse(jsonString);

        string StringLayerType = objects.RootElement.GetProperty("layerType").GetString() ?? "";
        LayerType layerType = (LayerType)Enum.Parse(typeof(LayerType), StringLayerType);

        string LayerName = objects.RootElement.GetProperty("LayerName").GetString() ?? "";

      var columnObject = objects.RootElement.GetProperty("ColumnObject");

      int width = columnObject.EnumerateObject().Count();
      int height = columnObject.EnumerateObject().First().Value.GetArrayLength();


      AbstractObject[,] abstractObjectMetrix = new AbstractObject[width,height];
        int x = 0;
        foreach (var column in columnObject.EnumerateObject())
        {
            
            string columnName = column.Name; // "Column_0", "Column_1", etc.
            JsonElement columnArray = column.Value;
            
            for (int row = 0; row < columnArray.GetArrayLength(); row++)
            {
                var cell = columnArray[row];

                string value = cell.GetString();

                if (value == "null")
                    continue;

                abstractObjectMetrix[x,row] = PolymorphicJson.AbstractObjectBuilder(value);
            }
            x++;
         } 

        return new Layer(layerType,LayerName,abstractObjectMetrix);
    }


}


