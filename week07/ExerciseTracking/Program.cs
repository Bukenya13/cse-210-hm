using System;
using System.Collections.Generic;

// Base Activity class
public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public DateTime GetDate() => _date;
    public int GetLengthInMinutes() => _lengthInMinutes;

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method that can be used by all derived classes
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_lengthInMinutes} min) - " +
               $"Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

// Running class
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        return (_distance / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }
}

// Cycling class
public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed) 
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetLengthInMinutes()) / 60;
    }

    public override double GetSpeed() => _speed;

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// Swimming class
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Convert laps to miles (each lap is 50 meters, 1000 meters = 1 km, 1 km = 0.62 miles)
        return (_laps * 50.0 / 1000) * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create activities of each type
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 1, 15), 30, 3.0),
            new Cycling(new DateTime(2025, 1, 16), 45, 15.0),
            new Swimming(new DateTime(2025, 1, 17), 60, 40)
        };

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("==========================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

        // Additional examples with different values
        Console.WriteLine("Additional Examples:");
        Console.WriteLine("====================");
        
        List<Activity> moreActivities = new List<Activity>
        {
            new Running(new DateTime(2025, 2, 10), 45, 4.5),
            new Cycling(new DateTime(2025, 2, 12), 60, 18.5),
            new Swimming(new DateTime(2025, 2, 14), 45, 30)
        };

        foreach (Activity activity in moreActivities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

        // More examples with current month
        Console.WriteLine("Current Month Activities:");
        Console.WriteLine("========================");
        
        List<Activity> currentActivities = new List<Activity>
        {
            new Running(new DateTime(2025, 10, 8), 35, 3.2),
            new Cycling(new DateTime(2025, 10, 9), 50, 16.0),
            new Swimming(new DateTime(2025, 10, 10), 40, 35)
        };

        foreach (Activity activity in currentActivities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}