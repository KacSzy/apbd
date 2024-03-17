using Microsoft.VisualBasic.CompilerServices;

public class Program
{
    public static void Main(string[] args) {
        Console.WriteLine("Commit 2");
        Console.WriteLine("Modyfikacja 3");
    }

    public static void CalculateAvg(int[] arr) {
        Console.WriteLine("CalculateAvg");
        for (int i = 0; i < arr.Length; i++) {
            Console.WriteLine(arr[i]);
        }
    }

    public static int MaxValue(int[] arr) {
        int max = -1;
        
        for(int i = 0; i < arr.Length; i++)
            if (arr[i] > max)
                max = arr[i];

        return max;
    }
    
}