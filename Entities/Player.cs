using Raylib_cs;
using Snake.Utils;

namespace Snake.Entities.Snake;

public class Player : Snake, IUpdatable, IDrawable
{
    public Player(int posX, int posY) : base(posX, posY)
    {
    }

    public void UpdateDirection()
    {
    }

    public new void Draw()
    {
        base.Draw();
    }
}