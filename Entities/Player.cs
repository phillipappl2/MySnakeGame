using Raylib_cs;
using Snake.Utils;

namespace Snake.Entities.Snake;

public class Player : Snake, IDrawable
{
    public Player(int posX, int posY, int maxBPM) : base(posX, posY)
    {
        BPM = maxBPM;
        elapsedTime = 0f;
    }

    public new void Draw()
    {
        base.Draw();
    }
}