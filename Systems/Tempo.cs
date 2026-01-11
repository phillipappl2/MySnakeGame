namespace Snake.Systems;

public class Tempo
{

    //its important that every int is even a number.
    //Tempo class is based on idea of music theory.
    
    
    //Singleton pattern 

    private static Tempo? _instance;
    public static Tempo Instance
        => _instance ?? throw new InvalidOperationException("Tempo ikke initialiseret");
    
    //TimeActions
    public delegate void TimeAction();
    private readonly List<(EvenNumber interval, Bpm bpm, TimeAction action)> _timeActions = new();
    
    //usage:
    //tempo.OnEvery(new EvenNumber(4),new Bpm(240), beat => Lamba expression for the action);
    
    public Tempo()
    {
        if (_instance != null) throw new InvalidOperationException("Game er allerede initialiseret");

        _instance = this;

        _ = CountAsync(new EvenNumber(240));
    }
    
 

    public void OnEvery(EvenNumber interval, Bpm bpm, TimeAction action)
    {
        _timeActions.Add((interval, bpm, action));
    }

    public void Remove(TimeAction action)
    {
        _timeActions.RemoveAll(x => x.action == action);
    }


    public int GetBarsPerMinute(EvenNumber numerator, Bpm bpm)
    {
        return bpm.Value / numerator.Value;
    }

    // counts up to 240 every min, 
    public async Task CountAsync(EvenNumber countTo, CancellationToken token = default)
    {
        var delayMs = (int)(TimeSpan.FromMinutes(1).TotalMilliseconds / countTo);

        while (!token.IsCancellationRequested)
            for (var i = 1; i <= countTo; i++)
            {
                var counter = i;
                
                foreach (var (interval, bpm, action) in _timeActions)
                    if (counter % (countTo / bpm.Value) == 0)
                        action();

                await Task.Delay(delayMs, token);
            }
    }
}

public class Bpm // Beats Per Minute
{
    public Bpm(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}

public class EvenNumber
{
    public EvenNumber(int value)
    {
        if (value % 2 != 0) throw new ArgumentException("The number must be even");

        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(EvenNumber evenNumber)
    {
        return evenNumber.Value;
    }
}