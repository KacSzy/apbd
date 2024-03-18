using zajecia2.Exceptions;

namespace zajecia2.Containers;

public abstract class Container
{
    protected static int howMany;
    
    protected string serialNumber;

    protected double weight; // [kg]
    protected double height; // [cm]
    protected double depth; // [cm]
    protected double maxCapacity; // [kg]
    
    protected double weightWithCargo; // [kg]

    public abstract void EmptyContainer();

    public abstract void Load(double cargo);

}














