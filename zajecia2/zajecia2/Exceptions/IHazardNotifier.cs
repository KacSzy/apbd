using zajecia2.Containers;

namespace zajecia2.Exceptions;

public interface IHazardNotifier
{
    static void Notify(Container container)
    {
        string serialNumber = container.GetSerialNumber();
        string[] temp = serialNumber.Split('-');
        string type = temp[1];
        switch (type) {
            case "L":
                bool IsDangerous = ((LiquidContainer)(container)).IsDangerous();
                if (IsDangerous) {
                    Console.WriteLine("Kontener o numerze seryjnym {" + serialNumber + "} zawiera niebezpieczny ładunek, więc można go napełnić jedynie do 50% pojemności");
                }
                else {
                    Console.WriteLine("Kontener o numerze seryjnym {" + serialNumber + "} nie może zostać napełniony do ponad 90% pojemności");
                }
                break;
            case "G":
                Console.WriteLine("W kontenerze o numerze seryjnym {" + serialNumber + "} zaszła niebezpieczna sytuacja!");
                break;
        }
    }
    
}