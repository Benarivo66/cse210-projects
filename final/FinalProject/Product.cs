public abstract class Product
{
    protected string _productName;
    protected int _productPrice;
    protected int _productQuantity;
    protected string _productID;
    protected bool _productIsAvailable;
    protected double _weight;

    public Product(string productName, int productPrice, int productQuantity, double weight)
    {   
        _productName = productName;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
        _productIsAvailable = true;
        _weight = weight;
        Random random = new Random();
        int randomNumber = random.Next(200, 10001);
        _productID = $"{_productName}{randomNumber}";
    }

    public string GetProductID()
    {
        return _productID;
    }
    public void SetPrice(int price)
    {
        _productPrice = price;
    }
    public void SetQuantity(int qty)
    {
        _productQuantity = qty;
    }

    public int GetQuantity()
    {
        return _productQuantity;
    }
    public int GetPrice()
    {
        return _productPrice;
    }
    public string GetName()
    {
        return _productName;
    }

    public virtual void SetAvailability()
    {
        if(_productQuantity > 0)
        {
            _productIsAvailable = true;
        }
        else
        {
            _productIsAvailable = false;
        }
    }

    public bool GetAvailability()
    {
        return _productIsAvailable;
    }

    public void updateProductPrice(int productPrice)
    {
        _productPrice = productPrice;
    }
    public void updateProductQuantity(int productQuantity)
    {
        _productQuantity = productQuantity;
    }
    public void DecrementProduct(int quantity)
    {
        _productQuantity -= quantity;
    }

    public abstract double GetShippingCost();
    



}