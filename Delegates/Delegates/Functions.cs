namespace Delegates;

public static class Functions
{
    public static List<TResult> Transform<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector)
    {
        var result = new List<TResult>();
        foreach (var item in source)
        {
            TResult value = selector(item);
            result.Add(value);
        }
        return result;
    }

    public static T Aggregate<T>(this List<T> numbers, T seed, Func<T, T, T> function)
    {
        T result = seed;

        foreach (var number in numbers)
        {
            result = function(result, number);
        }

        return result;
    }

    public static T FindFirst<T>(this List<T> collection, Func<T, bool> match)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));

        foreach (var item in collection)
        {
            if (match(item))
            {
                return item;
            }
        }

        return default;
    }

    public static List<T> FindAll<T>(this List<T> collection, Func<T, bool> match)
    {
        List<T> result = new List<T>();

        foreach (var item in collection)
        {
            if (match(item))
            {
                result.Add(item);
            }
        }

        return result;
    }
}