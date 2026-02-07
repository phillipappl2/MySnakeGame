using Raylib_cs;
using Snake.Utils;

namespace Snake.Entities.Snake;

public class Player : Snake, IDrawable
{
    public Player(int posX, int posY) : base(posX, posY)
    {
    }

    public new void Draw()
    {
        base.Draw();
    }
}