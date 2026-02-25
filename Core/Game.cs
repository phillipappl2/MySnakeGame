using System.Diagnostics;
using Raylib_cs;
using Snake.Entities.Snake;
using Snake.Utils;

namespace Snake.Assets;


public class Game
{
    //Git Test
    
    //Singleton pattern
    private static Game? _instance;
    private readonly string _title;

    Player player1 = new Player(10, 4, 60);
    Player player2 = new Player(10, 5, 120);

    public GameMap gameMap1;

    //_updatables contains all the interfaces that nee      
    // var layerList = d. be updated every frame.
    //_drawables contai     
    // var layerList = n all the interfaces that need. be drawn every frame.
    //It was important. separate the two because of the way the game loop works.
    private List<IDrawable> _drawables = [];
    private List<IUpdatable> _updatables = [];

    public Game(int width, int height, string title)
    {
        _instance = this;
        Width = width;
        Height = height;
        _title = title;
    }
    private int Width { get; }
    private int Height { get; }

    public void GameLoop()
    {
        Initalize();
        player2.Grow(player2._bodySegments[0]);

        while (!Raylib.WindowShouldClose())
        {
            HandleDirections();
            UpdateDirections();
            MoveSnakes();
            Draw();
        }

        Finalise();
    }

    private void Initalize()
    {
        Raylib.InitWindow(Width, Height, _title);
        Raylib.SetTargetFPS(60);

        //Updable objects are registered here
        RegsisterObject(player1);
        RegsisterObject(player2);
    }
    private void RegsisterObject(IUpdatable system)
    {
        _updatables.Add(system);

        if (system is IDrawable drawable) _drawables.Add(drawable);
    }

    private void HandleDirections()
    {
        foreach (var updatable in _updatables) {
        if (Raylib.IsKeyDown(KeyboardKey.A))
            updatable.SetDirection(Direction.Left);
        else if (Raylib.IsKeyDown(KeyboardKey.D))
            updatable.SetDirection(Direction.Right);
        else if (Raylib.IsKeyDown(KeyboardKey.W))
            updatable.SetDirection(Direction.Up);
        else if (Raylib.IsKeyDown(KeyboardKey.S))
            updatable.SetDirection(Direction.Down);
        }
    }

    private void UpdateDirections()
    { 
        foreach (var updatable in _updatables) updatable.UpdateDirection();
    }

    private void MoveSnakes()
    {
        float deltaTime = Raylib.GetFrameTime();

        foreach (var updatable in _updatables) {
            updatable.elapsedTime += deltaTime;
            while (updatable.elapsedTime >= 60f / updatable.BPM)
            {
                updatable.Move();
                updatable.elapsedTime -= 60f / updatable.BPM;
            }
        }
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        foreach (var drawable in _drawables) drawable.Draw();
        Raylib.ClearBackground(Color.LightGray);
        Raylib.EndDrawing();
    }

    private void Finalise()
    {
        Raylib.CloseWindow();
    }
}
