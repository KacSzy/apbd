// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main(string[] args) {
        //Console.WriteLine("Hello World!");

        // 1. Primitive
        int g = 10;
        int g2 = g;

        // 2. Complex
        string s = "Ala";
        string s2 = s;

        int[] arr = { 4, 3, 2, 2 };
        int[] arr2 = arr;
        arr2[0] = 2222;

        // -------

        int age = 10;
        //int? age -> mozna przypisac null
        //int? age -> Nullable<int> age
        //int ? class = null;
    }
}