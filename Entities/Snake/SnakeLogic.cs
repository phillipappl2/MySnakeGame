using Raylib_cs;
using Snake.Utils;

namespace Snake.Entities.Snake;

public class SnakeLogic
{
    private readonly List<Body> _body;
    

    private int LastX;
    private int LastY;

    private readonly int SnakeCellSize = 100;

    public SnakeLogic(int posX, int posY)
    {
        _body = [];
        _body.Add(new Body(posX, posY));

        LastX = posX;
        LastY = posY;
    }

    internal void UpdateSnakeLogic(Direction direction)
    {
        LastX = _body[^1].X;
        LastY = _body[^1].Y;
        for (var i = _body.Count - 1; i >= 1; i--)
        {
            _body[i].X = _body[i - 1].X;
            _body[i].Y = _body[i - 1].Y;
        }
         
        if (direction == Direction.Up)
            _body[0].Y -= 1;
        else if (direction == Direction.Down)
            _body[0].Y += 1;
        else if (direction == Direction.Left)
            _body[0].X -= 1;
        else if (direction == Direction.Right) _body[0].X += 1;
    }
    
    internal void Grow(Body body)
    {
        body.SetPositon(LastX, LastY);
        _body.Add(body);
    }

    private void Fill(Body body)
    {
        Raylib.DrawRectangle(body.X * SnakeCellSize, body.Y * SnakeCellSize, SnakeCellSize, SnakeCellSize, Color.Green);
    }

    public void Draw()
    {
        for (var i = 0; i < _body.Count; i++) Fill(_body[i]);
    }
}