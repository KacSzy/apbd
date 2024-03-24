using zajecia2.Exceptions;

namespace zajecia2.Containers;

public class CoolingContainer: Container, IHazardNotifier
{
    
    private string currType;
    private double temperature;
    private static Dictionary<string, double> products = new Dictionary<string, double>();

    private static void LoadProducts()
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
        if(!products.Any())
            LoadProducts();
    }

    public override void Load(double cargo)
    {
        List<String> indexes = new List<string>();

        int i = 0;
        foreach (var mapEntry in products) {
            Console.WriteLine(i + " - " + mapEntry.Key);
            indexes.Add(i.ToString());
        }

        bool isGood = false;
        int index = 0;
        while (!isGood) {
            Console.Write("> ");
            String line = Console.ReadLine();
            if (indexes.Contains(line)) {
                index = int.Parse(line);
                isGood = true;
            }
        }

        i = 0;
        foreach (var mapEntry in products) {
            if (i == index) {
                if (cargo < this.GetMaxCapacity()) {
                    this.AddCargo(cargo);
                    currType = mapEntry.Key;
                    temperature = mapEntry.Value;
                    return;
                }
                else {
                    Console.WriteLine("Too much cargo");
                    return;
                }
            }
        }
    }

    public override void EmptyContainer()
    {
        ResetWeightWithCargo(0);
        currType = "";
        temperature = 15;
    }
}