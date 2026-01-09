using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        // Core Requirement: Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Core Requirement: Average
        double average = (double)sum / numbers.Count;

        // Core Requirement: Largest number
        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        // Stretch Challenge: Smallest positive number
        int smallestPositive = int.MaxValue;
        bool foundPositive = false;

        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
                foundPositive = true;
            }
        }

        if (foundPositive)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch Challenge: Sort and display list
        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}