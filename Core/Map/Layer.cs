using Raylib_cs;

public class Layer
{
    public int Width{get;}
    public int Height{get;}
    public string LayerName{get;set;}
    public LayerType LayerType{get;}

    private AbstractObject[,] _layerMetrix;

    public Layer(LayerType layerType, AbstractObject[,] layerMetix, string layerName)
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
        {
            
            for (int y = 0; y < Height; y++)
            {

                if(_layerMetrix[x,y] is not null)
                {
                    
                     if(_layerMetrix[x,y] is IdrawObjcet drawObject)
                    {
                        
                        drawObject.Draw(x,y);

                    }

                }

            }

        }

    }
}
