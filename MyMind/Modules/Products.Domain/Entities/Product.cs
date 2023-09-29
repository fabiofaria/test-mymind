namespace Products.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(string name, decimal price)
    {
        CheckIfProductIsValid(name, price);

        Name = name;
        Price = price;
    }

    public void UpdateProduct(string name, decimal price)
    {
        CheckIfProductIsValid(name, price);

        Name = name;
        Price = price;
    }

    private static void CheckIfProductIsValid(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
    }
}
