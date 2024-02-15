public class Refridgerator : Product
{
    private int _capacity;

    public Refridgerator(string productName, int productPrice, int productQuantity, double weight, int capacity) : base(productName, productPrice, productQuantity, weight)
    {
        _productName = productName;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
        _productIsAvailable = true;
        _capacity = capacity;
        _weight = weight;
    }

    public int GetCapacity()
    {
        return _capacity;
    }

    public override double getShippingCost()
    {
        return 0.0002 * _weight * _productPrice;
    }

}