using Raylib_cs;
using Snake.Core.Timing;
using Snake.Entities.Snake;
using Snake.Utils;

namespace Snake.Assets;


public class Game
{
    //Singleton pattern
    private static Game? _instance;
    private readonly string _title;
    //Tempo tempo = new Tempo();
    int MaxBPM = 240;
    int currentBPM = 0;
    Player player = new Player(4, 4);

    //_updatables contains all the interfaces that need to be updated every frame.
    //_drawables contain all the interfaces that need to be drawn every frame.
    //It was important to separate the two because of the way the game loop works.
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
        //RegsisterObject(new Player(0, 0));
        RegsisterObject(player);
    }
    private void RegsisterObject(IUpdatable system)
    {
        _updatables.Add(system);

        if (system is IDrawable drawable) _drawables.Add(drawable);
    }

    private void HandleDirections()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A))
            player.SetDirection(Direction.Left);
        else if (Raylib.IsKeyDown(KeyboardKey.D))
            player.SetDirection(Direction.Right);
        else if (Raylib.IsKeyDown(KeyboardKey.W))
            player.SetDirection(Direction.Up);
        else if (Raylib.IsKeyDown(KeyboardKey.S))
            player.SetDirection(Direction.Down);
    }

    private void UpdateDirections()
    { 
        foreach (var updatable in _updatables) updatable.UpdateDirection();
    }

    private void MoveSnakes()
    {
        if ((currentBPM % (MaxBPM / 16)) == 0)
        {
            foreach (var updatable in _updatables) updatable.Move();
        }

        currentBPM++;
        currentBPM = currentBPM % MaxBPM;
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