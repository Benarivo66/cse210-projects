using System.Reflection.Metadata;

public class Store
{
    // private List<Product> _products;
    private List<Footwear> _footwears;
    private List<Tv> _tvs;
    private List<Phone> _phones;
    private List<Refridgerator> _refridgerators;
    private User _user;

    public Store()
    {
        // _products = new List<Product>();
        _footwears = new List<Footwear>();
        _tvs = new List<Tv>();
        _phones = new List<Phone>();
        _refridgerators = new List<Refridgerator>();
    }

    public void Start()
    {
        Console.WriteLine("Welcome to CSE210 Online Shopping Mall. Please Sign up if you do not have an account or Login if you have one");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Sign up");
        Console.WriteLine("Enter the appropriate number.");
        string entranceInputStr = Console.ReadLine();
        int entranceInput = int.Parse(entranceInputStr);

        Console.WriteLine("Enter your Name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Enter your Password: ");
        string userPassword = Console.ReadLine();
        if (entranceInput == 2)
        {
            Console.WriteLine("For now, lets leave it up to you. Will you be a customer or an admin? ");
        }
        string userType = Console.ReadLine();

        _user = new User(userName, userPassword, userType);
        if (entranceInput == 1)
        {
            _user.Login();
        }
        else if (entranceInput == 2)
        {
            _user.SignUp();
        }

        Console.WriteLine($"Welcome {userName}");
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Add Product(s)");
        Console.WriteLine("2. View Product(s)");
        Console.WriteLine("3. Update Product(s)");
        Console.WriteLine("4. Purchase Product(s)");
        Console.WriteLine("5. Log out");

        Console.WriteLine("Enter the number that corresponds to your choice.");
        string userActivityStr = Console.ReadLine();
        int userActivity = int.Parse(userActivityStr);
        while (userActivity != 5)
        {
            if (userActivity == 1)
            {
                Console.WriteLine("Enter the number that corresponds to your choice");
                Console.WriteLine("1. Add Footwear");
                Console.WriteLine("2. Add Tv");
                Console.WriteLine("3. Add Phone");
                Console.WriteLine("4. Add Refridgerator");
                Console.WriteLine("5. Done");

                Console.WriteLine("Enter the number that corresponds to your choice.");
                string optionStr = Console.ReadLine();
                int option = int.Parse(optionStr);
                Console.WriteLine(option);
                if (option == 1)
                {
                    Console.WriteLine("Enter the price");
                    string priceStr = Console.ReadLine();
                    int price = int.Parse(priceStr);
                    Console.WriteLine("Enter the quantity");
                    string qtyStr = Console.ReadLine();
                    int qty = int.Parse(qtyStr);
                    Console.WriteLine("Enter the weight");
                    string weightStr = Console.ReadLine();
                    double weight = double.Parse(weightStr);
                    Console.WriteLine("Enter the color");
                    string color = Console.ReadLine();
                    Console.WriteLine("Enter the size");
                    string sizeStr = Console.ReadLine();
                    int size = int.Parse(sizeStr);
                    Footwear footwear = new Footwear("footwear", price, qty, weight, color, size);
                    // _products.Add(footwear);
                    _footwears.Add(footwear);
                    Console.WriteLine("Footwear has been successfully added to store");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter the price");
                    string priceStr = Console.ReadLine();
                    int price = int.Parse(priceStr);
                    Console.WriteLine("Enter the quantity");
                    string qtyStr = Console.ReadLine();
                    int qty = int.Parse(qtyStr);
                    Console.WriteLine("Enter the weight");
                    string weightStr = Console.ReadLine();
                    double weight = double.Parse(weightStr);
                    Console.WriteLine("Enter the resolution");
                    string resolution = Console.ReadLine();
                    Console.WriteLine("Enter the size");
                    string sizeStr = Console.ReadLine();
                    int size = int.Parse(sizeStr);
                    Console.WriteLine("Enter the display technology");
                    string displaytech = Console.ReadLine();
                    Tv tv = new Tv("tv", price, qty, weight, size, resolution, displaytech);
                    // _products.Add(tv);
                    _tvs.Add(tv);
                    Console.WriteLine("Tv has been successfully added to store");
                }
                else if (option == 3)
                {
                    Console.WriteLine("Enter the price");
                    string priceStr = Console.ReadLine();
                    int price = int.Parse(priceStr);
                    Console.WriteLine("Enter the quantity");
                    string qtyStr = Console.ReadLine();
                    int qty = int.Parse(qtyStr);
                    Console.WriteLine("Enter the weight");
                    string weightStr = Console.ReadLine();
                    double weight = double.Parse(weightStr);
                    Console.WriteLine("Enter the ram");
                    string ram = Console.ReadLine();
                    Console.WriteLine("Enter the product type");
                    string productType = Console.ReadLine();
                    Console.WriteLine("Enter the battery capacity");
                    string battery = Console.ReadLine();
                    Phone phone = new Phone("phone", price, qty, weight, productType, ram, battery);
                    // _products.Add(phone);
                    _phones.Add(phone);
                    Console.WriteLine("Phone has been successfully added to store");
                }
                else if (option == 4)
                {
                    Console.WriteLine("Enter the price");
                    string priceStr = Console.ReadLine();
                    int price = int.Parse(priceStr);
                    Console.WriteLine("Enter the quantity");
                    string qtyStr = Console.ReadLine();
                    int qty = int.Parse(qtyStr);
                    Console.WriteLine("Enter the weight");
                    string weightStr = Console.ReadLine();
                    double weight = double.Parse(weightStr);
                    Console.WriteLine("Enter the capacity");
                    string capacityStr = Console.ReadLine();
                    int capacity = int.Parse(capacityStr);
                    Refridgerator refridgerator = new Refridgerator("refridgerator", price, qty, weight, capacity);
                    // _products.Add(refridgerator);
                    _refridgerators.Add(refridgerator);
                    Console.WriteLine("Refridgerator has been successfully added to store");
                }
            }
            else if (userActivity == 2)
            {
                Console.WriteLine("Enter the number that corresponds to your choice");
                Console.WriteLine("1. View Footwear");
                Console.WriteLine("2. View Tv");
                Console.WriteLine("3. View Phone");
                Console.WriteLine("4. View Refridgerator");
                Console.WriteLine("5. View All");

                Console.WriteLine("Enter the number that corresponds to your choice.");
                string optionStr = Console.ReadLine();
                int option = int.Parse(optionStr);
                if (option == 1)
                {
                    foreach (Footwear footwear in _footwears)
                    {
                        Console.WriteLine($"name:{footwear.GetName()}, price: {footwear.GetPrice()}, quantity available: {footwear.GetQuantity()}, color: {footwear.GetColor()}, size: {footwear.GetSize()}, id: {footwear.GetProductID()}");
                    }
                }
                else if (option == 2)
                {
                    foreach (Tv tv in _tvs)
                    {
                        Console.WriteLine($"name:{tv.GetName()}, price: {tv.GetPrice()}, quantity available: {tv.GetQuantity()}, display tech: {tv.GetDisplayTech()}, id: {tv.GetProductID()}");
                    }
                }
                else if (option == 3)
                {
                    foreach (Phone phone in _phones)
                    {
                        Console.WriteLine($"name:{phone.GetName()}, price: {phone.GetPrice()}, quantity available: {phone.GetQuantity()}, phone type: {phone.GetProductType()}, id: {phone.GetProductID()}");
                    }
                }
                else if (option == 4)
                {
                    foreach (Refridgerator refridgerator in _refridgerators)
                    {
                        Console.WriteLine($"name:{refridgerator.GetName()}, price: {refridgerator.GetPrice()}, quantity available: {refridgerator.GetQuantity()}, phone type: {refridgerator.GetCapacity()}, id: {refridgerator.GetProductID()}");
                    }
                }
                else if (option == 5)
                {
                    foreach (Footwear footwear in _footwears)
                    {
                        Console.WriteLine($"name:{footwear.GetName()}, price: {footwear.GetPrice()}, quantity available: {footwear.GetQuantity()}, color: {footwear.GetColor()}, size: {footwear.GetSize()}");
                    }
                    foreach (Tv tv in _tvs)
                    {
                        Console.WriteLine($"name:{tv.GetName()}, price: {tv.GetPrice()}, quantity available: {tv.GetQuantity()}, display tech: {tv.GetDisplayTech()}");
                    }
                    foreach (Phone phone in _phones)
                    {
                        Console.WriteLine($"name:{phone.GetName()}, price: {phone.GetPrice()}, quantity available: {phone.GetQuantity()}, phone type: {phone.GetProductType()}");
                    }
                    foreach (Refridgerator refridgerator in _refridgerators)
                    {
                        Console.WriteLine($"name:{refridgerator.GetName()}, price: {refridgerator.GetPrice()}, quantity available: {refridgerator.GetQuantity()}, phone type: {refridgerator.GetCapacity()}");
                    }
                }
            }
            else if (userActivity == 3)
            {
                Console.WriteLine("Enter the number that corresponds to your choice");
                Console.WriteLine("1. update Footwear price");
                Console.WriteLine("2. update Tv price");
                Console.WriteLine("3. update Phone price");
                Console.WriteLine("4. update Refridgerator price");

                Console.WriteLine("Enter the number that corresponds to your choice.");
                string optionStr = Console.ReadLine();
                int option = int.Parse(optionStr);

                Console.WriteLine("Enter the id of the product you want to update");
                string idStr = Console.ReadLine();

                Console.WriteLine("Enter the new price of the product.");
                string priceStr = Console.ReadLine();
                int price = int.Parse(priceStr);

                if (option == 1)
                {
                    foreach (Footwear footwear in _footwears)
                    {
                        if (footwear.GetProductID() == idStr)
                        {
                            footwear.SetPrice(price);
                            Console.WriteLine($"new price: {footwear.GetPrice()}");
                        }
                    }
                    if (option == 2)
                    {
                        foreach (Tv tv in _tvs)
                        {
                            if (tv.GetProductID() == idStr)
                            {
                                tv.SetPrice(price);
                                Console.WriteLine($"new price: {tv.GetPrice()}");
                            }
                        }
                    }
                    if (option == 3)
                    {
                        foreach (Phone phone in _phones)
                        {
                            if (phone.GetProductID() == idStr)
                            {
                                phone.SetPrice(price);
                                Console.WriteLine($"new price: {phone.GetPrice()}");
                            }
                        }
                    }
                    if (option == 4)
                    {
                        foreach (Refridgerator refridgerator in _refridgerators)
                        {
                            if (refridgerator.GetProductID() == idStr)
                            {
                                refridgerator.SetPrice(price);
                                Console.WriteLine($"new price: {refridgerator.GetPrice()}");
                            }
                        }
                    }
                }


            }

            Console.WriteLine($"Welcome {userName}");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add Product(s)");
            Console.WriteLine("2. View Product(s)");
            Console.WriteLine("3. Update Product(s)");
            Console.WriteLine("4. Purchase Product(s)");
            Console.WriteLine("5. Log out");

            Console.WriteLine("Enter the number that corresponds to your choice.");
            userActivityStr = Console.ReadLine();
            userActivity = int.Parse(userActivityStr);
        }
    }
}