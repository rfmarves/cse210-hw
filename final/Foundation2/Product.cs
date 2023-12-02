class Product
{
    private string _id;
    private string _name;
    private float _price;
    private float _quantity = 0;

    public Product(string id, string name, float price)
    {
        _id = id;
        _name = name;
        _price = price;
    }

    public float TotalPrice()
    {
        return _price * _quantity;
    }

    public void SetQuantity(float quantity)
    {
        _quantity = quantity;
    }

    public string Name()
    {
        return _name;
    }

    public string Id()
    {
        return _id;
    }

    public float Price()
    {
        return _price;
    }

    public float Quantity()
    {
        return _quantity;
    }
}