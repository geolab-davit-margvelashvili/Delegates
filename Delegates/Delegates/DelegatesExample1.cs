﻿namespace Delegates;

public static class DelegatesExample1
{
    public static void Run()
    {
        // დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ობიექტს

        var productService = new ProductService();
        var products = productService.GetProducts();

        var product = FindProduct(products, ProductIdChecker);
        product = FindProduct(products, ProductNameChecker);

        ProductChecker check = product => product.Id == 3;

        FindProduct(products, check);
        FindProduct(products, product => product.Id == 3);

        products.Find(ProductIdChecker);

        products.Find(p => p.Name == "Iphone");

        product = FindProduct(products, p => p.Name == "Iphone");
        product = FindProduct2(products, p => p.Manufacturer == "Microsoft");
        product = Find(products, p => p.Manufacturer == "Microsoft");

        var numbersSet = new HashSet<int> { 1, 2, 3, 4, 5, 6, 11, 12, 13, 15 };
        var numbersList = new HashSet<int> { 1, 2, 3, 4, 5, 6, 11, 12, 13, 15 };

        var number = Find(numbersSet, n => n < 0);
        number = Find(numbersSet, n => n > 10 && n % 2 == 0);
        number = Find(numbersList, n => n < 0);

        Console.Write("Enter Manufacturer: ");
        var manufacturer = Console.ReadLine();
        product = Find(products, p => p.Manufacturer == manufacturer);

        int a = 10;
        int b = 20;
        Sum(a, b);

        Sum(10, 20);
    }

    public delegate bool ProductChecker(Product product);

    public delegate bool CustomPredicate<T>(T element);

    private static int Sum(int number1, int number2) => number1 + number2;

    private static bool ProductIdChecker(Product product) => product.Id == 3;

    private static bool ProductNameChecker(Product product)
    {
        return product.Name == "Iphone";
    }

    public static Product FindProduct(List<Product> source, ProductChecker check)
    {
        foreach (var element in source)
        {
            if (check(element))
            {
                return element;
            }
        }

        return null;
    }

    public static Product FindProduct2(List<Product> source, CustomPredicate<Product> check)
    {
        foreach (var element in source)
        {
            if (check(element))
            {
                return element;
            }
        }

        return null;
    }

    public static T Find<T>(IEnumerable<T> source, CustomPredicate<T> check)
    {
        foreach (var element in source)
        {
            if (check(element))
            {
                return element;
            }
        }

        return default;
    }

    public class ProductIdEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (x == y)
                return true;

            if (x is null && y is not null)
                return false;

            if (x is not null && y is null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(Product obj)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductNameEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (x == y)
                return true;

            if (x is null && y is not null)
                return false;

            if (x is not null && y is null)
                return false;

            return x.Name == y.Name;
        }

        public int GetHashCode(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}