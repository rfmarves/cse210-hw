class Customer
{
    private string _id;
    private string _name;
    private Address _address;

    public Customer(string id, string name)
    {
        _id = id;
        _name = name;
    }

    public Customer(string id, string name, Address address)
    {
        _id = id;
        _name = name;
        _address = address;
    }

    public Customer(string id, string name, string streetAddress, string city, string state, string country)
    {
        _id = id;
        _name = name;
        _address = new Address(streetAddress, city, state, country);
    }

    public void AddAddress(Address address)
    {
        _address = address;
    }

    public Boolean LivesInUSA()
    {
        return _address.LivesInUSA();
    }

    public string Id()
    {
        return _id;
    }

    public string Name()
    {
        return _name;
    }

    public string AddressOneLine()
    {
        return _address.AddressOneLine();
    }

    public string AddressMultiLine()
    {
        return _address.AddressMultiLine();
    }

    public string ShippingLabel()
    {
        return $"{_name}\n{_address.AddressMultiLine()}";
    }
}