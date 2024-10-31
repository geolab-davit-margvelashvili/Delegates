namespace Delegates;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Product other)
        {
            return Id == other.Id;
        }

        return false;
    }
}