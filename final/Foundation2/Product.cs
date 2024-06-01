class Product
{
    private string _name;
    private int _id;
    private float _price;
    private int _quantity;

    public Product(string name, int id, float price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public float GetCost()
    {
        return _price * _quantity;
    }
    public int GetQuantity()
    {
        return _quantity;
    }

    public string GetPackingLabel()
    {
        return $"Name: {_name}, ID: {_id}, Quantity: {_quantity}";
    }
    public string GetIdentifierKey() //used for searching for specific product
    {
        return $"{_name};{_id};{_price}";
    }
    public void AddQuantity(int quantity)
    {
        _quantity += quantity;
    }
}