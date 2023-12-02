class Order
{
    ProductList _products = new ProductList();
    private Customer _customer;
    private float _shippingUSA = 5;
    private float _shippingWorld = 35;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product masterProduct, float quantity)
    {
        masterProduct.SetQuantity(quantity);
        _products.AddProduct(masterProduct);
    }

    public float Total()
    {
        float runningTotal =  _products.TotalPrice();
        if (_customer.LivesInUSA())
        {
            runningTotal += _shippingUSA;
        } else 
        {
            runningTotal += _shippingWorld;
        }
        return runningTotal;
    }

    public string PackingLabel()
    {
        string packLabel = $"Order for : {_customer.Name()}\n\n";
        packLabel += _products.PackingString();
        float shippingCost = 0;
        if (_customer.LivesInUSA()) {shippingCost = _shippingUSA;}
        else {shippingCost = _shippingWorld;}
        packLabel += $"\nShipping Cost: {String.Format("{0,49}",shippingCost)}\n";
        packLabel += $"Grand Total: {String.Format("{0,51}",Total())}\n";
        return packLabel;
    }

    public string ShippingLabel()
    {
        return _customer.ShippingLabel();
    }

    public string ShortDescription()
    {
        return $"{_customer.Name()}, with {_products.Count()} items";
    }
}