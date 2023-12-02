class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public Boolean LivesInUSA()
    {
        return (_country == "USA") || ( _country == "United States of America") || ( _country == "United States");
    }

    public void Print()
    {
        Console.WriteLine(_streetAddress);
        Console.WriteLine($"{_city}, {_state}");
        Console.WriteLine(_country);
    }

    public string AddressOneLine()
    {
        return $"{_streetAddress}, {_city}, {_state}, {_country}";
    }

    public string AddressMultiLine()
    {
        return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
    }
}