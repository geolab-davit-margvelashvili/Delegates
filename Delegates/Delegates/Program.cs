namespace Delegates;

internal delegate TResult Function<T1, T2, TResult>(T1 a, T2 b);

internal delegate TResult Function<T1, TResult>(T1 a);

internal delegate TResult Function<TResult>();

internal class TestClass<T>
{
    public T TestProp { get; set; }
}

internal class Program
{
    private static int Sum(int a, int b)
    {
        return a + b;
    }

    private static int Multiply(int a, int b)
    {
        return a * b;
    }

    private static void Main(string[] args)
    {
        //DelegatesExample1.Run();

        TestClass<int> test = new TestClass<int>();

        var numbers = new List<int> { -1, 10, 20, 15, -7, 50 };

        var sum = Aggregate(numbers, 0, Sum);
        var multiple = Aggregate(numbers, 1, Multiply);

        var min = FindMin(numbers);
        min = Aggregate(numbers, numbers[0], (result, number) => number < result ? number : result);
        var max = Aggregate(numbers, numbers[0], Max);

        var firstNegative = Find(numbers, number => number < 0);
        var firstPositive = Find(numbers, number => number > 0);
        var firstPositiveOdd = Find(numbers, number => number > 0 && number % 2 == 1);
        var allNegatives = FindAll(numbers, n => n < 0);

        var productService = new ProductService();
        var products = productService.GetProducts();

        var prices = Transform(products, product => product.Price);
        var totalPrice = Aggregate(prices, 0, (a, b) => a + b);

        prices = products.ConvertAll(product => product.Price);
        totalPrice = Aggregate(prices, 0, (a, b) => a + b);
    }

    private static List<TResult> Transform<TSource, TResult>(List<TSource> source, Func<TSource, TResult> selector)
    {
        var result = new List<TResult>();
        foreach (var item in source)
        {
            TResult value = selector(item);
            result.Add(value);
        }
        return result;
    }

    private static int Min(int result, int number) => number < result ? number : result;

    private static int Max(int result, int number) => number > result ? number : result;

    private static int FindMin(List<int> numbers)
    {
        int result = numbers[0];

        foreach (var number in numbers)
        {
            result = number < result ? number : result;
        }
        return result;
    }

    private static int FindMax(List<int> numbers)
    {
        int result = numbers[0];

        foreach (var number in numbers)
        {
            result = number > result ? number : result;
        }
        return result;
    }

    public static T Aggregate<T>(List<T> numbers, T seed, Func<T, T, T> function)
    {
        T result = seed;

        foreach (var number in numbers)
        {
            result = function(result, number);
        }

        return result;
    }

    public static T Find<T>(List<T> collection, Func<T, bool> match)
    {
        foreach (var item in collection)
        {
            if (match(item))
            {
                return item;
            }
        }

        return default;
    }

    public static List<T> FindAll<T>(List<T> collection, Func<T, bool> match)
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