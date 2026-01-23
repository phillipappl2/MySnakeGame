public class Bpm // Beats Per Minute
{
    public Bpm(int value)
    {
        Value = value;
    }
    public int Value { get; set; }

    public int GetBarsPerMinute(int numerator, Bpm bpm)
    {
        return bpm.Value / numerator;
    }
}
