namespace Snake.Entities.Snake;

public class SnakeLogic
{
    
    
    private List<Body> _body;
    private Body Head = new Body();

    private int LastX;
    private int LastY;
    
    public SnakeLogic(int posX, int posY)
    {
        _body = [];
        _body.Add(Head);
        
        LastX = posX;
        LastY = posY;

    }

    private void Update()
    {
        LastX = _body[^1].X; 
        LastY = _body[^1].Y;
        for (int i = _body.Count-1; i >= 1; i--)
        {
            _body[i].X = _body[i - 1].X;
            _body[i].Y = _body[i - 1].Y;
        }
    }

    private void Grow(Body body)
    {
        body.SetPositon(LastX, LastY);
        _body.Add(body);
        
    }

    private void Fill(Body body)
    {
        
        
    }
    
    private void Draw()
    {
        for (int i = 0; i < _body.Count; i++)
        {
            Fill(_body[i]);
        }
        
    }
    
}