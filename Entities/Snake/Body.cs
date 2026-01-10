namespace Snake.Entities.Snake;

public class Body
{
    
    public Body(int x = 0, int y = 0)
    {
        SetPositon(x, y);
    }
    
    public int X { get; set; }
    public int Y { get; set; }

    public void SetPositon(int x, int y)
    {
        (X, Y) = (x, y);
    }
}