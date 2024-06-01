class OrderManager
{
    private List<Order> _orders = new List<Order>();

    public OrderManager()
    {
        AddOrder(new Order(new Customer(new Address("1111 Street", "city#1", "state#1", "USA"), "name#1")),
        [
            new Product("Product #1-1", 1, 1.20f, 3),
            new Product("Product #1-2", 2, 1.50f, 5)
        ]);

        AddOrder(new Order(new Customer(new Address("2222 Street", "city#2", "state#2", "Canada"), "name#2")),
        [
            new Product("Product #2-1", 3, 1.80f, 3),
            new Product("Product #2-2", 4, 2.50f, 5),
            new Product("Product #2-3", 5, 0.30f, 7)
        ]);
    }

    public void HandleIO()
    {
        bool brk = false;
        while (!brk)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. View Orders");
            Console.WriteLine("2. Create New Order");
            Console.WriteLine("3. Quit (Default)");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Display();
                    break;
                case "2":
                    CreateOrder();
                    break;
                default:
                    brk = true;
                    break;
            }
        }
    }

    public void Display()
    {
        foreach (Order order in _orders)
        {
            order.Display();
            Console.WriteLine();
        }
    }
    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }
    public void AddOrder(Order order, Product[] products)
    {
        foreach (Product product in products)
        {
            order.AddProduct(product);
        }
        AddOrder(order);
    }
    public void CreateOrder()
    {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("What is your street address?");
        string streetAddress = Console.ReadLine();
        Console.WriteLine("What city/town do you live in?");
        string city = Console.ReadLine();
        Console.WriteLine("What state/province do you live in?");
        string state = Console.ReadLine();
        Console.WriteLine("What country do you live in?");
        string country = Console.ReadLine();

        Address address = new Address(streetAddress, city, state, country);
        Customer customer = new Customer(address, name);
        Order order = new Order(customer);

        bool brk = false;
        while (!brk)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add products");
            Console.WriteLine("2. Remove Products");
            Console.WriteLine("3. View Order");
            Console.WriteLine("4. Quit (Default)");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    order.AddProduct();
                    break;
                case "2":
                    order.RemoveProduct();
                    break;
                case "3":
                    order.Display();
                    break;
                default:
                    brk = true;
                    break;
            }
        }
        AddOrder(order);
    }
}