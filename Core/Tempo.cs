namespace Snake.Core.Timing;

public class Tempo
{
    //it's important that every int is even a number.
    //Tempo class is based on an idea of music theory.
    //Singleton pattern 

    private static Tempo? _instance;
    public static Tempo Instance
        => _instance ?? throw new InvalidOperationException("Tempo isn't initialised");
    
    //TimeActions
    public delegate void TimeAction();
    private readonly List<(Bpm bpm, TimeAction action)> _timeActions = new();
    
    //usage:
    //tempo.OnEvery(new WholeNumber(4),new Bpm(240), beat => Lamba expression for the action);
    public Tempo()
    {
        if (_instance != null) throw new InvalidOperationException("Tempo is already initialised");
        _instance = this;
        _ = CountAsync(240);
    }

    public void OnEvery(int interval, Bpm bpm, TimeAction action)
    {
        _timeActions.Add((bpm, action));
    }

    public void Remove(TimeAction action)
    {
        _timeActions.RemoveAll(x => x.action == action);
    }

    // counts up to desired bpm (right now 240) every min, 
    public async Task CountAsync(int countTo, CancellationToken token = default)
    {
        var delayMs = (int)(TimeSpan.FromMinutes(1).TotalMilliseconds / countTo);

        while (!token.IsCancellationRequested)
            for (var i = 1; i <= countTo; i++)
            {
                var counter = i;
                
                foreach (var ( bpm, action) in _timeActions)
                    if (counter % (countTo / bpm.Value) == 0)
                        action();

                await Task.Delay(delayMs, token);
            }
    }
}

