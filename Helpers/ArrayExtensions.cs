namespace ask.Helpers;

public static class ArrayExtensions
{
    public static void CheckElementAt<T>(this IEnumerable<T> array, int index)
    {
        if (array.ElementAtOrDefault(index) is null)
            throw new ParameterNullException();
    }
}