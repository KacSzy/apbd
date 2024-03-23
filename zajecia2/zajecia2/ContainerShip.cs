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
    
    //todo
    //usuniecie kontenera ze statku, rozladowanie kontenera, zastapienie kontenera ze statku o danym numerze innym kontenerem
    //mozliwosc przeniesienia kontenera miedzy dwoma statkami 
    //wypisanie informacji o danym kontenerze
    //wypisanie informacji o danym statku i jego ladnuku
    //dokonczyc cooling container
    //ewentualnie konsola
    
    
}