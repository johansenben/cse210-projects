class Customer
{
    private Address _address;
    private string _name;

    public Customer(Address address, string name)
    {
        _address = address;
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }
    public string GetAddress()
    {
        return _address.GetAddress();
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}