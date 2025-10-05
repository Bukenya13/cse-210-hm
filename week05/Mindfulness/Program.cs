using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exceeding Requirements:
            // 1. Added activity count tracking - keeps track of how many times each activity has been performed
            // 2. Enhanced menu with activity statistics display
            // 3. Added input validation for menu choices and duration
            
            int breathingCount = 0;
            int reflectionCount = 0;
            int listingCount = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                
                // Display statistics if any activities have been completed
                if (breathingCount > 0 || reflectionCount > 0 || listingCount > 0)
                {
                    Console.WriteLine("\n--- Activity Statistics ---");
                    Console.WriteLine($"Breathing activities completed: {breathingCount}");
                    Console.WriteLine($"Reflection activities completed: {reflectionCount}");
                    Console.WriteLine($"Listing activities completed: {listingCount}");
                    Console.WriteLine($"Total activities completed: {breathingCount + reflectionCount + listingCount}");
                }
                
                Console.Write("\nSelect a choice from the menu: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                }
                else if (choice == "2")
                {
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    reflectionCount++;
                }
                else if (choice == "3")
                {
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                }
                else if (choice == "4")
                {
                    Console.WriteLine("\nThank you for using the Mindfulness Program!");
                    Console.WriteLine($"You completed {breathingCount + reflectionCount + listingCount} activities total.");
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Please select 1-4.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}