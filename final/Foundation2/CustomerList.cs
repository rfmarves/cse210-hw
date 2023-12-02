class CustomerList
{
    private List<Customer> _customers;

    public CustomerList()
    {
        _customers = new List<Customer>();
    }

    public void AddCustomer(string id, string name, string streetAddress, string city, string state, string country)
    {
        _customers.Add(new Customer( id,  name,  streetAddress,  city,  state,  country));
    }

    public void LoadFromFile(string fileName)
    {
        string line;
        using StreamReader sr = new StreamReader(fileName);
        while (sr.Peek() >= 0)
        {
            line = sr.ReadLine();
            string[] parts = line.Split("|");
            AddCustomer(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
        }
    }

    public Customer CustomerByID(string ID)
    {
        Customer returnValue = new Customer("000000", "Customer Not Found", "", "", "","");
        foreach (Customer c in _customers)
        {
            if (c.Id() == ID)
            {
                returnValue = c;
                break;
            }
        }
        return returnValue;
    }

    public void Print()
    {
        Console.WriteLine("ID   | Name : Address");
        foreach (Customer c in _customers)
        {
            Console.WriteLine($"{c.Id()} | {c.Name()} : {c.AddressOneLine()}");
        }
    }
}
