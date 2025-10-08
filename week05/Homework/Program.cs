using System;
using System.Collections.Generic;
using System.Threading;

// Base Activity Class
public abstract class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;
    
    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }
    
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
    
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_activityName} Activity.");
        ShowSpinner(3);
    }
    
    protected void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        
        string[] spinner = { "|", "/", "-", "\\" };
        int spinnerIndex = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[spinnerIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
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

// Breathing Activity Class
public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) {}
    
    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        Console.WriteLine();
        
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();
            
            if (DateTime.Now >= endTime) break;
            
            Console.Write("Breathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }
}

// Reflection Activity Class
public class ReflectionActivity : Activity
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
    
    public ReflectionActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    ) {}
    
    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();
        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < futureTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(8);
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }
    
    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
    
    private string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }
}

// Listing Activity Class
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    
    private List<string> _items = new List<string>();
    private Random _random = new Random();
    
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) {}
    
    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        
        int itemCount = 0;
        
        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }
        
        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items!");
        
        DisplayEndingMessage();
    }
    
    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("===================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Choose an activity (1-4): ");
            
            string choice = Console.ReadLine();
            
            Activity activity = null;
            
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
            }
            
            activity.Run();
        }
    }
}