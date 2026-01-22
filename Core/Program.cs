using Raylib_cs;
using System.Numerics;
using Snake.Assets;
using Colors = Raylib_cs.Color;

class Program
{
    static void Main()
    {
        var game = new Game(1600, 700, "Snake");
        game.Run();
    }
}