public class SnakeSegment
{
    private VisualElements visualElements;

    public SnakeSegment(VisualElements visualElements)
    {
        this.visualElements = visualElements;
    }

    public void Draw(int x, int y)
    {
        visualElements.Draw(x, y);
    }
}