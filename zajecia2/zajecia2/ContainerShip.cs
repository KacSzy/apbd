using Microsoft.VisualBasic.CompilerServices;
using zajecia2.Containers;

namespace zajecia2;

public class ContainerShip
{
    private List<Container> containers = new List<Container>();
    private double maxSpeed;
    private int maxContainers;
    private int currContainers;
    private double maxContainersWeight; // [t]
    private double currContainerWeight;

    public ContainerShip(double maxSpeed, int maxContainers, double maxContainersWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainers = maxContainers;
        this.maxContainersWeight = maxContainersWeight;
        currContainers = 0;
        currContainerWeight = 0;
    }

    public void addContainer(Container container)
    {
        if (containers.Count == maxContainers) {
            Console.WriteLine("Nie mozesz dodac kontenera, poniewaz przekroczysz limit statku.");
        }
        else {
            if(currContainerWeight + container.GetWeightWithCargo() > maxContainersWeight)
                Console.WriteLine("Nie mozesz dodac tego kontenera, poniewaz jest za ciezki. Maksymalna waga zostanie przekroczona.");
            else {
                currContainers++;
                currContainerWeight += container.GetWeightWithCargo();
                containers.Add(container);
            }
        }
    }

    public void addContainersList(List<Container> containersToAdd)
    {
        double tempWeight = 0;
        int tempContainers = 0;
        for (int i = 0; i < containersToAdd.Count; i++) {
            Container container = containersToAdd[i];
            tempWeight += container.GetWeightWithCargo();
            tempContainers++;
        }

        int containersInTheFuture = tempContainers + currContainers;
        double weightInTheFuture = tempWeight + currContainerWeight;

        if (containersInTheFuture <= maxContainers && weightInTheFuture <= maxContainersWeight) {
            currContainers += currContainers;
            tempContainers += tempContainers;
            for(int i = 0; i < containersToAdd.Count; i++)
                containers.Add(containersToAdd[i]);
        }
        
    }

    public void removeContainer(Container container)
    {
        if (containers.Contains(container)) {
            containers.Remove(container);
            currContainers--;
            currContainerWeight -= container.GetWeightWithCargo();
        }
        else {
            Console.WriteLine("Nie ma takiego kontenera na statku");
        }
    }

    public void removeContainer()
    {
        List<String> indexes = new List<string>();
        for (int i = 0; i < containers.Count; i++) {
            Console.WriteLine(i + " - " + containers[i].GetSerialNumber());
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

        Container container = containers[index];
        currContainers--;
        currContainerWeight -= container.GetWeightWithCargo();
        containers.Remove(container);
    }

    public void switchContainers(Container container)
    {
        removeContainer();
        containers.Add(container);
        currContainers++;
        currContainerWeight += container.GetWeightWithCargo();
    }

    public void moveContainer(ContainerShip containerShip)
    {
        List<String> indexes = new List<string>();
        for (int i = 0; i < containers.Count; i++) {
            Console.WriteLine(i + " - " + containers[i].GetSerialNumber());
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

        if (containerShip.CheckContainerBeforeAdding(containers[index])) {
            containerShip.addContainer(containers[index]);
            this.removeContainer(containers[index]);
        }
        else {
            Console.WriteLine("Nie mozna przeniesc tego kontenera.");
        }
        
    }

    public bool CheckContainerBeforeAdding(Container container)
    {
        if (this.currContainerWeight + container.GetWeightWithCargo() > maxContainersWeight)
            return false;
        if (currContainers + 1 > maxContainers)
            return false;
        return true;
    }

    public override string ToString()
    {
        string result = "This ship's max speed is " + maxSpeed + ". " +
                        "It has " + currContainers + "/" + maxContainers + "containers" +
                        "and it weights " + currContainerWeight + "/" + maxContainersWeight + "kg.";
        
        return result;
    }
}