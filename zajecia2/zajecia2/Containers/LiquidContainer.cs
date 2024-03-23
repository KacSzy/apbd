using zajecia2.Exceptions;

namespace zajecia2.Containers;

public class LiquidContainer: Container, IHazardNotifier
{
    
    private bool isDangerous;

    public LiquidContainer(double weight, double height, double depth, double maxCapacity) :
        base(weight, height, depth, maxCapacity)
    {
        SetSerialNumber("KON-L-" + GetId());
    }

    public override void Load(double liters)
    {
        Console.Write("Czy jest to bezpieczny ładunek? T/N");
        bool isGood = false;
        string decision = "";
        while (!isGood) {
            decision = Console.ReadLine();
            if (decision.Equals("T") || decision.Equals("N"))
                isGood = true;
        }

        if (decision.Equals("T"))
            isDangerous = false;
        else
            isDangerous = true;
        
        double capacityToTest = ( liters/this.GetCapacity() ) * 100;

        if (capacityToTest > 100) {
            OverfillException ofe = new OverfillException("Nie możesz napelnic kontenera ponad jego pojemnosc {" +
                                        this.GetSerialNumber() + "}");
            Console.WriteLine(ofe.StackTrace);
            isGood = false;
        }
        if (isDangerous) {
            if (capacityToTest > 50) {
                IHazardNotifier.Notify(this);
                isGood = false;
            }
        }
        else {
            if (capacityToTest > 90) {
                IHazardNotifier.Notify(this);
                isGood = false;
            }
        }

        if (isGood) {
            AddCargo(liters);
        }
        
    }

    public override void EmptyContainer()
    {
        ResetWeightWithCargo(0);
    }

    public bool IsDangerous()
    {
        return isDangerous;
    }
}