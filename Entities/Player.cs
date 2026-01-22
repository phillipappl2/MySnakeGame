using Raylib_cs;
using Snake.Utils;

namespace Snake.Entities.Snake;

public class PlayerSnake : Snake, IUpdatable, IDrawable
{
    public PlayerSnake(int posX, int posY) : base(posX, posY)
    {
    }

    public new void Draw()
    {
        base.Draw();
    }

    public void UpdateDirection()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A))
            SetDirection(Direction.Left);
        else if (Raylib.IsKeyDown(KeyboardKey.D))
            SetDirection(Direction.Right);
        else if (Raylib.IsKeyDown(KeyboardKey.W))
            SetDirection(Direction.Up);
        else if (Raylib.IsKeyDown(KeyboardKey.S))
            SetDirection(Direction.Down);
    }
}