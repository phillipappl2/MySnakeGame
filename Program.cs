using Raylib_cs;
using System.Numerics;
using Snake.Assets;
using colors = Raylib_cs.Color;

class Program
{
    static void Main()
    {
        var game = new Game(600, 600, "Snake");
        game.Run();
     
    }
}