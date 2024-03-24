using zajecia2.Exceptions;

namespace zajecia2.Containers;

public class GasContainer: Container, IHazardNotifier
{
    private double preassure; // [atm]

    public GasContainer(double weight, double height, double depth, double maxCapacity) : base(weight, height, depth, maxCapacity)
    {
        SetSerialNumber("KON-G-" + GetId());
    }

    public void DangerousSituation()
    {
        IHazardNotifier.Notify(this);
    }

    public override void Load(double cargo)
    {
        double capacityToTest = ( cargo/this.GetCapacity() ) * 100;
        bool isGood = true;
        if (capacityToTest > 100) {
            OverfillException ofe = new OverfillException("Nie możesz napelnic kontenera ponad jego pojemnosc {" +
                                                          this.GetSerialNumber() + "}");
            Console.WriteLine(ofe.StackTrace);
            isGood = false;
        }

        if (isGood) {
            AddCargo(cargo);
        }
        Console.WriteLine("Podaj cisnienie ładunku: ");
        Console.Write("> ");
        string pres = Console.ReadLine();
        this.preassure = Convert.ToDouble(pres);
    }

    public override void EmptyContainer()
    {
        this.ResetWeightWithCargo(0.05);
    }
}