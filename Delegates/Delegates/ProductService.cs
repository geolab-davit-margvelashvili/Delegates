namespace Delegates;

public class ProductService
{
    public List<Product> GetProducts()
    {
        var products = new List<Product>
        {
            new Product()
            {
                Id = 1,
                Manufacturer = "Microsoft",
                Name = "Surface Book",
                Price = 1023.50m,
            },
            new Product()
            {
                Id = 2,
                Manufacturer = "Microsoft",
                Name = "Surface Laptop",
                Price = 2023.50m,
            },

            new Product()
            {
                Id = 3,
                Manufacturer = "Apple",
                Name = "Iphone",
                Price = 8063.50m,
            },
            new Product()
            {
                Id = 4,
                Manufacturer = "Microsoft",
                Name = "Windows 11",
                Price = 6023.50m,
            },
            new Product()
            {
                Id = 5,
                Manufacturer = "Apple",
                Name = "Macbook",
                Price = 7023.50m,
            }
        };

        return products;
    }
}