public class GetTypeByName
{

// Source - https://stackoverflow.com/a/20008954
// Posted by pil0t, modified by community. See post 'Timeline' for change history
// Retrieved 2026-01-30, License - CC BY-SA 4.0

    public static Type ByName(string name)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Reverse())
        {
            var tt = assembly.GetType(name);
            if (tt != null)
            {
                return tt;
            }
        }

        return null;
    }

}