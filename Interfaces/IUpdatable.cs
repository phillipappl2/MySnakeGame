using System.Buffers.Binary;

namespace Snake.Utils;

public interface IUpdatable
{
    int BPM
    {
        get;
        set;
    }
    void UpdateDirection();
    void Move();
}