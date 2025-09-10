using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userInput = -1;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        
        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            userInput = int.Parse(input);
            
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }
        
       
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        
        
        float average = (float)sum / numbers.Count;
     
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        
        
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
        
       
        numbers.Sort();
        s
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        
        
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}