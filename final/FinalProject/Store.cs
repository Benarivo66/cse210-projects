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
        try
        {
            // string[] promptNumList = { "1", "2", "3", "4", "5" };

            openingMessage();
            string entranceInputStr = Console.ReadLine();

            if(entranceInputStr != "1" || entranceInputStr != "2")
            {
                throw new CustomException(CustomException.ErrorCode.InvalidInput, "Invalid input");
            }
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

            openingPrompt(userName);
            string userActivityStr = Console.ReadLine();
            // if(promptNumList.Contains(userActivityStr) == false)
            // {
            //     throw new CustomException(CustomException.ErrorCode.InvalidInput, "Invalid input");
            // }
            int userActivity = int.Parse(userActivityStr);

            while (userActivity != 5)
            {
                if (userActivity == 1)
                {
                    AddProducts();
                }
                else if (userActivity == 2)
                {
                    ViewProducts();
                }
                else if (userActivity == 3)
                {
                    UpdateProducts();
                }
                else if (userActivity == 4)
                {
                    PurchaseProducts();
                }
                else
                {
                    throw new CustomException(CustomException.ErrorCode.InvalidInput, "Invalid input");
                }

                openingPrompt(userName);
                userActivityStr = Console.ReadLine();
                userActivity = int.Parse(userActivityStr);
            }
        }
        catch (CustomException exception)
        {
            Console.WriteLine(exception.Message);
    //         switch (exception.Code)
    // {
    //     case CustomException.ErrorCode.UserNotFound:
    //         Console.WriteLine("User not found");
    //         break;
    //     case CustomException.ErrorCode.IdNotFound:
    //         Console.WriteLine("ID not found");
    //         break;
    //     case CustomException.ErrorCode.InvalidInput:
    //         Console.WriteLine("Invalid input");
    //         break;
        
    //     default:
    //         Console.WriteLine("An error occurred: " + exception.Message);
    //         break;
    // }
        }
    }

    public void getInvoice()
    {
        foreach (string inv in _invoice)
        {
            Console.WriteLine(inv);
        }
    }

    private void openingMessage()
    {
        Console.WriteLine("Welcome to CSE210 Online Shopping Mall. Please Sign up if you do not have an account or Login if you have one");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Sign up");
        Console.WriteLine("Enter the appropriate number.");
    }

    private void openingPrompt(string userName)
    {
        Console.WriteLine($"Welcome {userName}");
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Add Product(s)");
        Console.WriteLine("2. View Product(s)");
        Console.WriteLine("3. Update Product(s)");
        Console.WriteLine("4. Purchase Product(s)");
        Console.WriteLine("5. Log out");
        Console.WriteLine("Enter the number that corresponds to your choice.");
    }

    private void actionPrompt(string action)
    {
        Console.WriteLine($"1. {action} Footwear");
        Console.WriteLine($"2. {action} Tv");
        Console.WriteLine($"3. {action} Phone");
        Console.WriteLine($"4. {action} Refridgerator");
        Console.WriteLine("Enter the number that corresponds to your choice.");
    }

    private (int, int, double) GetProductsCommonDetails()
    {
        Console.WriteLine("Enter the price");
        string priceStr = Console.ReadLine();
        //check invalid Input Exception
        int price = int.Parse(priceStr);
        Console.WriteLine("Enter the quantity");
        string qtyStr = Console.ReadLine();
        //check invalid Input Exception
        int qty = int.Parse(qtyStr);
        Console.WriteLine("Enter the weight");
        string weightStr = Console.ReadLine();
        //check invalid Input Exception
        double weight = double.Parse(weightStr);
        Console.WriteLine("Enter the color");

        return (price, qty, weight);
    }

    private void ViewAllProducts()
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

    public void AddProducts()
    {
        actionPrompt("Add");
        string optionStr = Console.ReadLine();
        //check invalid input Exception
        int option = int.Parse(optionStr);
        Console.WriteLine(option);
        if (option == 1)
        {
            (int price, int qty, double weight) = GetProductsCommonDetails();
            string color = Console.ReadLine();
            Console.WriteLine("Enter the size");
            string sizeStr = Console.ReadLine();
            //check invalid Input Exception
            int size = int.Parse(sizeStr);
            Footwear footwear = new Footwear("footwear", price, qty, weight, color, size);
            _footwears.Add(footwear);
            Console.WriteLine("Footwear has been successfully added to store");
        }
        else if (option == 2)
        {
            (int price, int qty, double weight) = GetProductsCommonDetails();
            Console.WriteLine("Enter the resolution");
            string resolution = Console.ReadLine();
            Console.WriteLine("Enter the size");
            string sizeStr = Console.ReadLine();
            //check invalid Input Exception
            int size = int.Parse(sizeStr);
            Console.WriteLine("Enter the display technology");
            string displaytech = Console.ReadLine();
            Tv tv = new Tv("tv", price, qty, weight, size, resolution, displaytech);
            _tvs.Add(tv);
            Console.WriteLine("Tv has been successfully added to store");
        }
        else if (option == 3)
        {
            (int price, int qty, double weight) = GetProductsCommonDetails();
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
            (int price, int qty, double weight) = GetProductsCommonDetails();
            Console.WriteLine("Enter the capacity");
            string capacityStr = Console.ReadLine();
            //check invalid Input Exception
            int capacity = int.Parse(capacityStr);
            Refridgerator refridgerator = new Refridgerator("refridgerator", price, qty, weight, capacity);
            _refridgerators.Add(refridgerator);
            Console.WriteLine("Refridgerator has been successfully added to store");
        }
    }

    public void ViewProducts()
    {
        actionPrompt("View");
        Console.WriteLine("5. View All");
        Console.WriteLine("6. View Invoice");

        Console.WriteLine("Enter the number that corresponds to your choice.");
        string optionStr = Console.ReadLine();
        //check invalid Input Exception
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
            ViewAllProducts();
        }
        else if (option == 6)
        {
            getInvoice();
            Console.WriteLine($"total cost of purchase made is {_total}");
        }
    }

    public void UpdateProducts()
    {
        actionPrompt("Update");
        string optionStr = Console.ReadLine();
        //check invalid Input Exception
        int option = int.Parse(optionStr);

        Console.WriteLine("Enter the id of the product you want to update");
        string idStr = Console.ReadLine();

        Console.WriteLine("Enter the new price of the product.");
        string priceStr = Console.ReadLine();
        //check invalid Input Exception
        int price = int.Parse(priceStr);
        bool productFound = false;

        if (option == 1)
        {
            foreach (Footwear footwear in _footwears)
            {
                if (footwear.GetProductID() == idStr)
                {
                    productFound = true;
                    footwear.SetPrice(price);
                    Console.WriteLine($"new price: {footwear.GetPrice()}");
                }
            }
            if (productFound == false)
            {
                throw new CustomException(CustomException.ErrorCode.IdNotFound, "Id not found");
            }
        }
        if (option == 2)
        {
            foreach (Tv tv in _tvs)
            {
                if (tv.GetProductID() == idStr)
                {
                    productFound = true;
                    tv.SetPrice(price);
                    Console.WriteLine($"new price: {tv.GetPrice()}");
                }
            }
            if (productFound == false)
            {
                Console.WriteLine($"phone with id {idStr}  not found");
            }
        }
        if (option == 3)
        {
            foreach (Phone phone in _phones)
            {
                if (phone.GetProductID() == idStr)
                {
                    productFound = true;
                    phone.SetPrice(price);
                    Console.WriteLine($"new price: {phone.GetPrice()}");
                }
            }
            if (productFound == false)
            {
                Console.WriteLine($"phone with id {idStr}  not found");
            }
        }
        if (option == 4)
        {
            foreach (Refridgerator refridgerator in _refridgerators)
            {
                if (refridgerator.GetProductID() == idStr)
                {
                    productFound = true;
                    refridgerator.SetPrice(price);
                    Console.WriteLine($"new price: {refridgerator.GetPrice()}");
                }
            }
            if (productFound == false)
            {
                Console.WriteLine($"phone with id {idStr}  not found");
            }
        }

    }

    public void PurchaseProducts()
    {
        actionPrompt("Purchase");
        string optionStr = Console.ReadLine();
        //check invalid Input Exception
        int option = int.Parse(optionStr);

        Console.WriteLine("Enter the id of the product you want to purchase");
        string idStr = Console.ReadLine();

        Console.WriteLine("Enter the quantity of the product you want to purchase");
        string qtyStr = Console.ReadLine();
        int qty = int.Parse(qtyStr);
        bool productFound = false;

        if (option == 1)
        {
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

}