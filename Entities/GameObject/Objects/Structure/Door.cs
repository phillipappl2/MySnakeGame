using System.Text.Json.Serialization;
using Raylib_cs;

public class Door : StaticStructure, IdrawObjcet
{

    private bool isOpen;

    [JsonIgnore]
    private VisualElements visualElements;

    public Door(VisualElements visualElements)
    {
        this.visualElements = visualElements;
        isOpen = false;
    }

    public Door(VisualElements visualElements, bool isOpen)
    {
        
        this.visualElements = visualElements;
        this.isOpen = isOpen;

    }
 
    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }

    public bool IsDoorOpen()
    {
        return isOpen;
    }

    public void Draw(int x, int y)
    {
       if(isOpen == false)
        {
            
            visualElements.Draw(x,y);

        }
    }
}
