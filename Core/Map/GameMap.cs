using System.Text.Json;
using Snake.Assets;
using Snake.Utils;

public class GameMap : IDrawable
{
    public static GameMap? _instance;
    private Level? LoadedLevel;

    public GameMap()
    {
        _instance = this;
    }

    public void LoadLevel(Level level)
    {
        
        LoadedLevel = level;

    }

     public void Draw()
    {



    }



   
}