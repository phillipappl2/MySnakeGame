using System.ComponentModel;
using System.Text;
using System.Text.Json;
using Raylib_cs;

public class Wall : StaticStructure, IdrawObjcet, Istructure
{

     VisualElements _visualElements;

    public Wall(VisualElements visualElements)
    {
        this._visualElements = visualElements;
    }


    public void Draw(int x, int y)
    {
        _visualElements.Draw(x, y);
    }

    public string JsonConstructor(Wall obj)
    {
        throw new NotImplementedException();
    }

    public Wall JsonDestructor(string data)
    {
        throw new NotImplementedException();
    }

    public VisualElements GetVisualElement()
    {
        return _visualElements;
    }
}