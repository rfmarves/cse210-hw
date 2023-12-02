using System.Globalization;

class ProductList
{
    private List<Product> _products;
    
    public ProductList()
    {
        _products = new List<Product>();
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    
    public void AddProduct(string id, string name, float price)
    {
        _products.Add(new Product(id, name, price));
    }
    public void LoadFromFile(string fileName)
    {
        string line;
        using StreamReader sr = new StreamReader(fileName);
        while (sr.Peek() >= 0)
        {
            line = sr.ReadLine();
            string[] parts = line.Split("|");
            AddProduct(parts[0], parts[1], float.Parse(parts[2]));
        }
    }

    public Product ProductByID(string ID)
    {
        Product returnValue = new Product("000000", "Product Not Found", 0);
        foreach (Product p in _products)
        {
            if (p.Id() == ID)
            {
                returnValue = p;
                break;
            }
        }
        return returnValue;
    }

    public void Print()
    {
        Console.WriteLine("ID     | Description - Price");
        foreach (Product p in _products)
        {
            Console.WriteLine($"{p.Id()} | {p.Name()} - ${p.Price()}");
        }
    }

    public string PackingString()
    {
        string returnString = "ID     | Description                      | Qty | Price | Total\n";
        foreach (Product p in _products)
        {
            returnString += $"{p.Id()} | {String.Format("{0,-32}", p.Name())} | {String.Format("{0,3}", p.Quantity())} | {String.Format("{0,5}", p.Price())} | {String.Format("{0,6}",p.TotalPrice())}\n";
        }
        returnString += $"Products Total: {String.Format("{0,48}",TotalPrice())}\n";
        return returnString;
    }

    public float TotalPrice()
    {
        float runningTotal = 0;
        foreach (Product p in _products)
        {
            runningTotal += p.TotalPrice();
        }
        return runningTotal;
    }

    public int Count()
    {
        return _products.Count();
    }
}