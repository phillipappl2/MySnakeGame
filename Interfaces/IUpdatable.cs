using System.Buffers.Binary;

namespace Snake.Utils;

public interface IUpdatable
{
    int BPM { get; set; }
    float elapsedTime { get; set; }
    void UpdateDirection();
    void SetDirection(Direction direction);
    void Move();
}