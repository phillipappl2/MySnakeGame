using Raylib_cs;
using Snake.Entities.Snake;
using Snake.Utils;

namespace Snake.Assets;

public class Game
{
    //Singleton pattern

    private static Game? _instance;
    private readonly List<IDrawable> _drawables = [];
    private readonly string _title;

    //_updatables contains all the interfaces that need to be updated every frame.
    //_drawables contain all the interfaces that need to be drawn every frame.
    //It was important to separate the two because of the way the game loop works.

    private readonly List<IUpdatable> _updatables = [];


    public Game(int width, int height, string title)
    {
        if (_instance != null) throw new InvalidOperationException("Game er allerede initialiseret");

        _instance = this;
        Width = width;
        Height = height;
        _title = title;
    }

    public static Game Instance
        => _instance ?? throw new InvalidOperationException("Game ikke initialiseret");

    private int Width { get; }

    private int Height { get; }

    public void Run()
    {
        Initalize();

        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }

        Cleanup();
    }

    private void Update()
    {
        foreach (var updatable in _updatables) updatable.Update();
    }

    private void Initalize()
    {
        Raylib.InitWindow(Width, Height, _title);
        Raylib.SetTargetFPS(5);

        //Updable systems are registered here.

        Regsister(new EnemySnake(0, 0));

        Regsister(new EnemySnake(4, 4));
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);

        foreach (var drawable in _drawables) drawable.Draw();


        Raylib.EndDrawing();
    }

    private void Cleanup()
    {
        Raylib.CloseWindow();
    }

    private void Regsister(IUpdatable system)
    {
        _updatables.Add(system);

        if (system is IDrawable drawable) _drawables.Add(drawable);
    }
}