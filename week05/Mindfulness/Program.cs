using System;
using System.Collections.Generic;
using System.Threading;

/*
EXCEEDING REQUIREMENTS:
1. Prompts and reflection questions are not repeated until all have been used once in a session.
2. Spinner and countdown animations are used during pauses.
*/

abstract class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}

// ------------------------------------------------------

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Start();

        int elapsed = 0;

        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            elapsed += 4;

            if (elapsed >= _duration) break;

            Console.Write("\nBreathe out... ");
            ShowCountdown(6);
            elapsed += 6;
        }

        End();
    }
}

// ------------------------------------------------------

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();
    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public ReflectionActivity()
        : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Run()
    {
        Start();

        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions:");
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(5);
        }

        End();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);
        return question;
    }
}

// ------------------------------------------------------

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();
    private List<string> _unusedPrompts;

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        Start();

        _unusedPrompts = new List<string>(_prompts);

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("\nStart listing items. Press Enter after each one:");

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");

        End();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }
}

// ------------------------------------------------------

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
