using System.Reflection.Metadata;

public class Store
{
    private List<Footwear> _footwears;
    private List<Tv> _tvs;
    private List<Phone> _phones;
    private List<Refridgerator> _refridgerators;
    private User _user;
    private List<string> _invoice;
    private double _total;

    public Store()
    {
        _footwears = new List<Footwear>();
        _tvs = new List<Tv>();
        _phones = new List<Phone>();
        _refridgerators = new List<Refridgerator>();
        _invoice = new List<string>();
        _total = 0;
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
        string userType;
        if (entranceInput == 2)
        {
            Console.WriteLine("For now, lets leave it up to you. Will you be a customer or an admin? ");
            userType = Console.ReadLine();
            _user = new User(userName, userPassword, userType);
            _user.SignUp();
        }
        else if (entranceInput == 1)
        {
            _user = new User(userName, userPassword);
            _user.Login();
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
                Console.WriteLine("6. View Invoice");

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
                else if (option == 6)
                {
                    getInvoice();
                    Console.WriteLine($"total cost of purchase made is {_total}");
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
            else if (userActivity == 4)
            {
                Console.WriteLine("Enter the number that corresponds to your choice");
                Console.WriteLine("1. purchase Footwear");
                Console.WriteLine("2. purchase Tv");
                Console.WriteLine("3. purchase Phone");
                Console.WriteLine("4. purchase Refridgerator");

                Console.WriteLine("Enter the number that corresponds to your choice.");
                string optionStr = Console.ReadLine();
                int option = int.Parse(optionStr);

                Console.WriteLine("Enter the id of the product you want to purchase");
                string idStr = Console.ReadLine();

                Console.WriteLine("Enter the quantity of the product you want to purchase");
                string qtyStr = Console.ReadLine();
                int qty = int.Parse(qtyStr);

                if (option == 1)
                {
                    bool productFound = false;
                    foreach (Footwear footwear in _footwears)
                    {
                        if (footwear.GetProductID() == idStr)
                        {
                            int originalQty = footwear.GetQuantity();
                            if (originalQty >= qty)
                            {
                                productFound = true;
                                double totalCost = (qty * footwear.GetPrice()) + footwear.GetShippingCost();
                                Console.WriteLine("You have successfully made an order of:");
                                string purchaseInfo = $"{qty} footwear(s) at a total price of {totalCost}";
                                Console.WriteLine(purchaseInfo);


                                int newQty = originalQty - qty;
                                footwear.SetQuantity(newQty);
                                _total += totalCost;
                                _invoice.Add(purchaseInfo);

                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantity desired is greater than quantity available");
                        }
                    }
                    if (productFound == false)
                    {
                        Console.WriteLine($"footwear with id {idStr}  not found");
                    }
                }

                if (option == 2)
                {
                    bool productFound = false;
                    foreach (Tv tv in _tvs)
                    {
                        if (tv.GetProductID() == idStr)
                        {
                            int originalQty = tv.GetQuantity();
                            if (originalQty >= qty)
                            {
                                productFound = true;
                                double totalCost = (qty * tv.GetPrice()) + tv.GetShippingCost();
                                Console.WriteLine("You have successfully made an order of:");
                                string purchaseInfo = $"{qty} tv(s) at a total price of {totalCost}";
                                Console.WriteLine(purchaseInfo);


                                int newQty = originalQty - qty;
                                tv.SetQuantity(newQty);
                                _total += totalCost;
                                _invoice.Add(purchaseInfo);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantity desired is greater than quantity available");
                        }
                    }
                    if (productFound == false)
                    {
                        Console.WriteLine($"tv with id {idStr}  not found");
                    }
                }

                if (option == 3)
                {
                    bool productFound = false;
                    foreach (Phone phone in _phones)
                    {
                        if (phone.GetProductID() == idStr)
                        {
                            int originalQty = phone.GetQuantity();
                            if (originalQty >= qty)
                            {
                                productFound = true;
                                double totalCost = (qty * phone.GetPrice()) + phone.GetShippingCost();
                                Console.WriteLine("You have successfully made an order of:");
                                string purchaseInfo = $"{qty} phone(s) at a total price of {totalCost}";
                                Console.WriteLine(purchaseInfo);


                                int newQty = originalQty - qty;
                                phone.SetQuantity(newQty);
                                _total += totalCost;
                                _invoice.Add(purchaseInfo);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantity desired is greater than quantity available");
                        }
                    }
                    if (productFound == false)
                    {
                        Console.WriteLine($"phone with id {idStr}  not found");
                    }
                }

                if (option == 4)
                {
                    bool productFound = false;
                    foreach (Refridgerator refridgerator in _refridgerators)
                    {
                        if (refridgerator.GetProductID() == idStr)
                        {
                            int originalQty = refridgerator.GetQuantity();
                            if (originalQty >= qty)
                            {
                                productFound = true;
                                double totalCost = (qty * refridgerator.GetPrice()) + refridgerator.GetShippingCost();
                                Console.WriteLine("You have successfully made an order of:");
                                string purchaseInfo = $"{qty} refridgerator(s) at a total price of {totalCost}";
                                Console.WriteLine(purchaseInfo);

                                int newQty = originalQty - qty;
                                refridgerator.SetQuantity(newQty);
                                _total += totalCost;
                                _invoice.Add(purchaseInfo);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantity desired is greater than quantity available");
                        }
                    }
                    if (productFound == false)
                    {
                        Console.WriteLine($"refridgerator with id {idStr}  not found");
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

    public void getInvoice()
    {
        foreach(string inv in _invoice)
        {
            Console.WriteLine(inv);
        }
    }
}