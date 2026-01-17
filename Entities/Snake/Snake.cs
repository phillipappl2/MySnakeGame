using Raylib_cs;
using Snake.Core.Timing;
using Snake.Utils;

namespace Snake.Entities.Snake;

public class Snake
{
    private readonly List<Segment> _bodySegments;
    private readonly int _snakeCellSize = 100;

    private Direction _direction = Direction.Left;

    private int _lastX;
    private int _lastY;

    public void SetDirection(Direction direction)
    {
        _direction = direction;
    }
    
    public Snake(int posX, int posY)
    {
        //Makes the head of the snake at the given position.
        _bodySegments = [new Segment(posX, posY)];

        _lastX = posX;
        _lastY = posY;
        
        Tempo tempo = Tempo.Instance;
        tempo.OnEvery(new EvenNumber(4),new Bpm(120), () => Move(_direction));
    }
    
    public void Move(Direction direction)
    {
        
        UpdateOrder();
        
        if (_direction == Direction.Up)
            _bodySegments[0].Y -= 1;
        else if (_direction == Direction.Down)
            _bodySegments[0].Y += 1;
        else if (_direction == Direction.Left)
            _bodySegments[0].X -= 1;
        else if (_direction == Direction.Right) _bodySegments[0].X += 1;
    }

    private void UpdateOrder()
    {
        _lastX = _bodySegments[^1].X; // or _body[body.count-1].X
        _lastY = _bodySegments[^1].Y; // or _body[body.count-1].Y

        for (var i = _bodySegments.Count - 1; i >= 1; i--)
        {
            _bodySegments[i].X = _bodySegments[i - 1].X;
            _bodySegments[i].Y = _bodySegments[i - 1].Y;
        }
        
    }
    

     public void Grow(Segment segment)
    {
        //even if you assign the body to a position in the parameter, it is overriden by the next line.
        //Idk if this is a bad implementation or not.
        segment.SetPositon(_lastX, _lastY);
        _bodySegments.Add(segment);
    }
    

    private void Fill(Segment segment)
    {
        Raylib.DrawRectangle(segment.X * _snakeCellSize, segment.Y * _snakeCellSize, _snakeCellSize, _snakeCellSize,
            Color.Green);
    }

    public void Draw()
    {
        foreach (var body in _bodySegments)
            Fill(body);
    }
}