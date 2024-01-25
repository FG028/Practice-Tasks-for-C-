using System;

class TwoDimensionalArray
{
    //
    //Step 1: Create a two-dimensional array of dimensions 8x8.
    //Step 2: Fill the array with random numbers in the range from -50 to 50.
    //Step 3: Output only those array elements that are ODD and positive.
    //Step 4: Count the number of elements that satisfy this condition.
    //Step 5: If the number of such elements is MORE than 5, move to the next line.
    //Step 6: Count the number of elements that satisfy the condition.
    //Step 7: Display the count after displaying the array itself.
    //Step 8: Find the maximum value among the received elements.
    //Step 9: Display the maximum value after the array.
    static void Main(string[] args)
    {
        // Create a 2D array of dimensions 8x8
        int[,] array = new int[8, 8];

        // Fill the array with random numbers in the range from -50 to 50
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(-50, 51);
            }
        }
        // Count the number of elements that are ODD and positive
        int oddPositiveElements = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] % 2 == 1 && array[i, j] > 0)
                {
                    oddPositiveElements++;
                }
            }
        }
        // Output the array elements that are ODD and positive
        Console.WriteLine("ODD and positive elements:");
        int elementCount = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] % 2 == 1 && array[i, j] > 0)
                {
                    Console.Write(array[i, j] + "\t");
                    elementCount++;

                    if (elementCount > 5)
                    {
                        Console.WriteLine();
                        elementCount = 0;
                    }
                }
            }
        }
        // Find the maximum value among the received elements
        int maxElement = array[0, 0];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] > maxElement)
                {
                    maxElement = array[i, j];
                }
            }
        }
        // Display the maximum value
        Console.WriteLine();
        Console.WriteLine("Maximum element: " + maxElement);
    }
}