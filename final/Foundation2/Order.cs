class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product newProduct)
    {
        string identifier = newProduct.GetIdentifierKey();
        foreach (Product product in _products)
        {
            if (product.GetIdentifierKey() == identifier)
            {
                product.AddQuantity(newProduct.GetQuantity());
                return;
            }
        }
        _products.Add(newProduct);
    }
    public void AddProduct()
    {
        int InputPositiveInt(){
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input > 0)
                        return input;
                }
                Console.WriteLine("Input must be a positive integer!");
            }
        }
        float InputPositiveFloat(){
            while (true)
            {
                try
                {
                    float input = float.Parse(Console.ReadLine());
                    if (input > 0)
                        return input;
                }
                catch {}
                Console.WriteLine("Input must be a positive decimal number!");
            }
        }
        Console.WriteLine("What is the product name?");
        string name = Console.ReadLine();
        Console.WriteLine("What is the product ID?");
        int id = InputPositiveInt();
        Console.WriteLine("What is the price per item?");
        float price = InputPositiveFloat();
        Console.WriteLine("What is the quantity?");
        int quantity = InputPositiveInt();
        

        AddProduct(new Product(name, id, price, quantity));
    }
    public void RemoveProduct()
    {
        int InputPositiveInt(){
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input > 0)
                        return input;
                }
                Console.WriteLine("Input must be a positive integer!");
            }
        }
        float InputPositiveFloat(){
            while (true)
            {
                try
                {
                    float input = float.Parse(Console.ReadLine());
                    if (input > 0)
                        return input;
                }
                catch {}
                Console.WriteLine("Input must be a positive decimal number!");
            }
        }
        Console.WriteLine("What is the product name?");
        string name = Console.ReadLine();
        Console.WriteLine("What is the product ID?");
        int id = InputPositiveInt();
        Console.WriteLine("What is the price per item?");
        float price = InputPositiveFloat();

        for (int i = 0; i < _products.Count; i++)
        {
            if ($"{name};{id};{price}" == _products[i].GetIdentifierKey())
            {
                Console.WriteLine($"How many items do you want to remove? (Current Quantity is {_products[i].GetQuantity()})");
                int quantity = InputPositiveInt();
                _products[i].AddQuantity(-1 * quantity);
                if (_products[i].GetQuantity() <= 0)
                {
                    _products.Remove(_products[i]);
                }
                return;
            }
        }
        Console.WriteLine("Item doesn't exist!");
    }
    public void Display()
    {
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(GetShippingLabel());
        Console.WriteLine("Packing Label:");
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine("Costs:");
        Console.WriteLine($"Shipping Cost: ${GetShippingCost().ToString("0.00")}");
        Console.WriteLine($"Total Cost: ${GetTotalCost().ToString("0.00")}");
    }
    public float GetTotalCost()
    {
        float totalCost = GetShippingCost();
        foreach (Product product in _products)
        {
            totalCost += product.GetCost();
        }
        return totalCost;
    }
    public string GetPackingLabel()
    {
        string packingLabel = "";
        int count = 0;
        foreach (Product product in _products)
        {
            packingLabel += product.GetPackingLabel();
            if (count < _products.Count - 1) //don't create new line after last item
                packingLabel += '\n';
            count++;
        }
        return packingLabel;
    }
    public string GetShippingLabel()
    {
        return $"{_customer.GetName()} ... {_customer.GetAddress()}";
    }

    public float GetShippingCost()
    {
        if (_customer.LivesInUSA())
            return 5.00f;
        else
            return 35.00f;
    }
}