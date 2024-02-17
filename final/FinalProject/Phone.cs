public class Phone : Product
{
    private string _productType;
    private string _ram;
    private string _battery;

    public Phone(string productName, int productPrice, int productQuantity, double weight, string productType, string ram, string battery) : base(productName, productPrice, productQuantity, weight)
    {
        _productName = productName;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
        _productIsAvailable = true;
        _productType = productType;
        _ram = ram;
        _battery = battery;
        _weight = weight;
    }

    public string GetProductType()
    {
        return _productType;
    }

    public override double GetShippingCost()
    {
        return 0.05 * _weight * _productPrice;
    }

}