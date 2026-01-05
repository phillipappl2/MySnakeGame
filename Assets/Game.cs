namespace Snake.Assets;
using Raylib_cs;

public class Game
{
    
    private static Game? _instance;
    public static Game Instance
        => _instance ?? throw new InvalidOperationException("Game ikke initialiseret");
  
    
    private readonly int _width;
    private readonly int _height;
    private readonly string _title;
    
    //offentlige properties så andre klasser kan bruge
    private int Width => _width;
    private int Height => _height;
    
    
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
        
    }

    private void Update()
    {
        
    }
    
    private void Initalize()
    {
       
        Raylib.InitWindow(_width, _height, _title);
        Raylib.SetTargetFPS(60);
        
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(color:Color.RayWhite);
        
        Raylib.EndDrawing();
        
    }

    private void Cleanup()
    {
        
        Raylib.CloseWindow();
        
    }
    
}