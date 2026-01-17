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

    public void Update()
    {


        if (Raylib.IsKeyDown(KeyboardKey.A))
            Move(Direction.Left);
        else if (Raylib.IsKeyDown(KeyboardKey.D))
            Move(Direction.Right);
        else if (Raylib.IsKeyDown(KeyboardKey.W))
            Move(Direction.Up);
        else if (Raylib.IsKeyDown(KeyboardKey.S))
            Move(Direction.Down);
    }
}