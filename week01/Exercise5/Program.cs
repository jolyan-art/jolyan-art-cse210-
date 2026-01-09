using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);

        DisplayResult(name, squared);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int value;
        while (!int.TryParse(input, out value))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
            input = Console.ReadLine();
        }
        return value;
    }

    static int SquareNumber(int value)
    {
        return value * value;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}