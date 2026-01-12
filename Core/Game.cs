using Snake.Entities.Snake;
using Snake.Utils;

namespace Snake.Assets;
using Raylib_cs;

public class Game
{
    
    //Singleton pattern
    
    private static Game? _instance;
    public static Game Instance
        => _instance ?? throw new InvalidOperationException("Game ikke initialiseret");
  
    
    private readonly int _width;
    private readonly int _height;
    private readonly string _title;
    
    private int Width => _width;
    private int Height => _height;

    //_updatables contains all the interfaces that need to be updated every frame.
    //_drawables contain all the interfaces that need to be drawn every frame.
    //It was important to separate the two because of the way the game loop works.
    
    private readonly List<IUpdatable> _updatables = [];
    private readonly List<IDrawable> _drawables = [];
    
    public Game(int width, int height, string title)
    {
        if (_instance != null)
        {
            throw new InvalidOperationException("Game er allerede initialiseret");
        }
       
        _instance = this;
        _width = width;
        _height = height;
        _title = title;
        
    }
    
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
        
        foreach (var updatable in _updatables)
        {
            updatable.Update();
        }
    
    }
    
    private void Initalize()
    {
       
        Raylib.InitWindow(_width, _height, _title);
        Raylib.SetTargetFPS(5);
        
        //Updable systems are registered here.
        
        Regsister(new EnemySnake(0,0));
        
        Regsister(new EnemySnake(4,4));
        

    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(color:Color.RayWhite);
        
        foreach (var drawable in _drawables)
        {
            drawable.Draw();
        }

        
        Raylib.EndDrawing();
        
    }

    private void Cleanup()
    {
        
        Raylib.CloseWindow();
        
    }

    private void Regsister(IUpdatable system)
    {
        
        _updatables.Add(system);
        
        if (system is IDrawable drawable)
        {
            _drawables.Add(drawable);
        }

        
    }
    
}