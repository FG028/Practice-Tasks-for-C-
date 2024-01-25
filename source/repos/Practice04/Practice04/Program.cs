
using System;
public class ArraysComparison {
    // Method 1 Initialize array
    public void InitializeArray(int[] array) {
        Console.WriteLine("Enter elements for the array");
        Console.Clear();
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Element a position {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
            Console.Clear();
        }
    }
    // Method 2 Display elements on screen
    public void DisplayArray(int[] array)
    {
        for (int i = 0;i < array.Length; i++)
        {
            Console.WriteLine("{0}\t", array[i]);
        }
        Console.WriteLine();
    }
    // Method 3: Sort array in desc. order
    public void SortArrayDescending(int[] array)
    {
        for(int i = 0; i < array.Length -1; i++)
        {
            for(int j = 0; j < array.Length - i -1; j++)
            {
                if (array[j] < array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
    // Method 4 Check for equivalent
    public bool isEqual(int[] array1, int[] array2)
    {
        if(array1.Length != array2.Length) return false;
        for(int i = 0; i < array2.Length ; i++) 
        {
            if(array1[i] != array2[i]) return false;
        }
        return true;
    }
}
class MainClass
{
    static void Main(string[] args) 
    {
        ArraysComparison arraysComparison = new ArraysComparison();

        // Declare two arrays of size 5
        int[] array1 = new int[5];
        int[] array2 = new int[5];

        //Initialize arrays from the console

        arraysComparison.InitializeArray(array1);
        arraysComparison.InitializeArray(array2);

        //Display arrays before sorting

        Console.WriteLine("Array 1:");
        arraysComparison.DisplayArray(array1);
        Console.WriteLine();

        Console.WriteLine("Array 2:");
        arraysComparison.DisplayArray(array2);
        Console.WriteLine();

        //Sorting

        arraysComparison.SortArrayDescending(array1);
        arraysComparison.SortArrayDescending(array2);

        //Display arrays
        Console.WriteLine("Array 1 (Sorted):");
        arraysComparison.DisplayArray(array1);
        Console.WriteLine();

        Console.WriteLine("Array 2 (Sorted):");
        arraysComparison.DisplayArray(array2);
        Console.WriteLine();

        //Check for equivalent

        bool areEquivalent = arraysComparison.isEqual(array1, array2);
        if (areEquivalent)
        {
            Console.WriteLine("Arrays are equivalent!!!");
        } else 
        { 
            Console.WriteLine("Arrays are not equivalent!!!"); 
        }
    }
}