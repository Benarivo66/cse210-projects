public class Footwear : Product
{
    private string _color;
    private int _size;

    public Footwear(string productName, int productPrice, int productQuantity, double weight, string color, int size) : base(productName, productPrice, productQuantity, weight)
    {
        _productName = productName;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
        _productIsAvailable = true;
        _weight = weight;
        _color = color;
        _size = size;
    }

    public override double getShippingCost()
    {
        return 0.001 * _weight * _productPrice;
    }

    public string GetColor()
    {
        return _color;
    }

    public int GetSize()
    {
        return _size;
    }

}