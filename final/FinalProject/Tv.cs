public class Tv : Product
{
    private int _size;
    private string _resolution;
    private string _displaytech;
    

    public Tv(string productName, int productPrice, int productQuantity, double weight, int size, string resolution, string displaytech) : base(productName, productPrice, productQuantity, weight)
    {
        _productName = productName;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
        _productIsAvailable = true;
        _size = size;
        _resolution = resolution;
        _displaytech = displaytech;
        _weight = weight;
    }

    public string GetDisplayTech()
    {
        return _displaytech;
    }

    public override double GetShippingCost()
    {
        return 0.0025 * _weight * _productPrice;
    }

}