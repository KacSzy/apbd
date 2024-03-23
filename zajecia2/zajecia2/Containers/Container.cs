using zajecia2.Exceptions;

namespace zajecia2.Containers;

public abstract class Container
{
    private static int howMany = 0;
    
    private string serialNumber;

    private double weight; // [kg]
    private double height; // [cm]
    private double depth; // [cm]
    private double maxCapacity; // [kg]
    
    private double weightWithCargo; // [kg]

    protected Container(double weight, double height, double depth, double maxCapacity)
    {
        this.serialNumber = serialNumber;
        this.weight = weight;
        this.height = height;
        this.depth = depth;
        this.maxCapacity = maxCapacity;
        weightWithCargo = weight;
    }

    public abstract void Load(double cargo);
    public abstract void EmptyContainer();


    public int GetId()
    {
        return howMany++;
    }
    
    public string GetSerialNumber()
    {
        return serialNumber;
    }

    public double GetWeightWithCargo()
    {
        return weightWithCargo;
    }

    public void SetSerialNumber(string number)
    {
        serialNumber = number;
    }

    public double GetCapacity()
    {
        return maxCapacity;
    }

    public void ResetWeightWithCargo(double howMuchShouldStay)
    {
        weightWithCargo = weight + (weightWithCargo - weight) * howMuchShouldStay;
    }

    public void AddCargo(double cargo)
    {
        weightWithCargo = weight + cargo;
    }

}














