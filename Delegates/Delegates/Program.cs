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

        var sum = numbers.Aggregate(0, Sum);
        var multiple = Functions.Aggregate(numbers, 1, Multiply);

        var min = numbers.Aggregate(numbers[0], (result, number) => number < result ? number : result);

        var firstNegative = numbers.Find(number => number < 0);
        var firstPositive = numbers.Find(number => number > 0);
        var firstPositiveOdd = numbers.Find(number => number > 0 && number % 2 == 1);
        var allNegatives = numbers.FindAll(n => n < 0);

        var productService = new ProductService();
        var products = productService.GetProducts();

        var totalPrice =

            Functions.Aggregate(
            Functions.Transform(
                Functions.FindAll(products, product => product.Price > 2000m),
                product => product.Price),
            0, (a, b) => a + b);

        totalPrice = products
            .FindAll(product => product.Price > 2000m)
            .Transform(product => product.Price)
            .Sum();

        totalPrice = products
             .Where(x => x.Price > 2000m)
             .Select(x => x.Price)
             .Sum();
    }
}