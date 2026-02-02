using System.Dynamic;

public class Level
{

    public List<Layer> _layers{ get; set; }

    public Level(List<Layer> layers)
    {

        //sort the layers so it fits _layerTypes enum
        layers.Sort((a, b) => a.LayerType.CompareTo(b.LayerType));
        this._layers = layers;


        //Check if the layers are the samme size
        for (int i = 1; i < _layers.Count; i++)
        {
          if ((_layers[i].Width != _layers[i-1].Width) ||
               _layers[i].Height != _layers[i-1].Height)
          {
            throw new Exception("Layers " + _layers[i-1].LayerType +
                                " and" + _layers[i].LayerType + " not the same size");
          }
        }

        //Get all layernames
        var names = _layers.Select(p => p.LayerName).ToList();

        //Check if layers have the same name
        if(names.Count != names.Distinct().Count())
        {
            throw new Exception("There are more then one layer with the same name");
        }
    }

  public bool GetLayer(LayerType layerType,out List<Layer> layer)
  {
    
    layer = _layers
        .Where(p => p.LayerType == layerType)
        .ToList();

    return layer.Count > 0;

  }

  //Layer of type with name.
  public bool GetLayer(LayerType layerType,string layerName,Layer layer)
  {
    
    layer = _layers
        .Where(p => p.LayerType == layerType && p.LayerName == layerName)
        .FirstOrDefault()!;

    return layer != null;

  }

  public void AddLayer(Layer layer)
  {
    
    _layers.Add(layer);

  }

  public void AddLayer(List<Layer> layer)
  {
    
    foreach(var l in layer)
    {
        _layers.Add(l);
    }

  }

  public List<Layer> GetAllLayes()
  {
    
    return _layers;

  }

  public void Draw()
  {
    
    foreach(var layer in _layers)
    {
        
        layer.Draw();

    }

  }
}
