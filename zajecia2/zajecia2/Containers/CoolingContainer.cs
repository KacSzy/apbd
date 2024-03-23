using zajecia2.Exceptions;

namespace zajecia2.Containers;

public class CoolingContainer: Container, IHazardNotifier
{
    
    private string type;
    private double temperature;
    private static Dictionary<string, double> products = new Dictionary<string, double>();

    public static void LoadProducts()
    {
        products.Add("Bananas", 13.3);
        products.Add("Chocolate", 18.0);
        products.Add("Fish", 2.0);
        products.Add("Meat", -15.0);
        products.Add("Ice cream", -18.0);
        products.Add("Frozen pizza", -30.0);
        products.Add("Cheese", 7.2);
        products.Add("Sausages", 5.0);
        products.Add("Butter", 20.5);
        products.Add("Eggs", 19.0);
    }
    
    public CoolingContainer(double weight, double height, double depth, double maxCapacity) : base(weight, height, depth, maxCapacity)
    {
        SetSerialNumber("KON-C-" + GetId());
    }

    public override void Load(double cargo)
    {
        
    }

    public override void EmptyContainer()
    {
        
    }
}