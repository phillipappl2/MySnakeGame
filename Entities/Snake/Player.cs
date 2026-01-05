using Raylib_cs;
using Snake.Utils;

namespace Snake.Entities.Snake;

public class Player : SnakeLogic, IUpdatable, IDrawable
{
    public Player(int posX, int posY) : base(posX, posY)
    {
        
    }

    public void Update()
    {
        Console.WriteLine("Player.Update() kaldes!");

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            UpdateSnakeLogic(Direction.Left);
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            UpdateSnakeLogic(Direction.Right);
        }
        else if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            UpdateSnakeLogic(Direction.Up);
        }
        else if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            UpdateSnakeLogic(Direction.Down);
        }
    }
    
    public new void Draw()
    {
        base.Draw();
    }

}