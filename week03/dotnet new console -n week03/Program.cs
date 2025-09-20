using System;
using System.Collections.Generic;

/// <summary>
/// Scripture Memorizer Program - CSE 210 W03 Project
/// 
/// CREATIVITY AND EXCEEDING REQUIREMENTS:
/// 1. Multiple Scripture Library: Program includes a library of scriptures that are randomly selected
/// 2. Enhanced User Experience: Added scripture completion percentage display
/// 3. Smart Word Selection: Words are only selected for hiding if they aren't already hidden (no duplicate hiding)
/// 4. Progress Tracking: Shows how many words remain visible
/// 5. Colorful Console Output: Uses different colors for reference, text, and hidden words (where supported)
/// 6. Scripture Categories: Includes scriptures from different categories (faith, hope, charity, etc.)
/// 7. Restart Option: After completing a scripture, user can choose to practice another
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Create scripture library
        ScriptureLibrary library = new ScriptureLibrary();
        
        bool continueProgram = true;
        
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("This program will help you memorize scriptures by gradually hiding words.");
        Console.WriteLine();
        
        while (continueProgram)
        {
            // Get random scripture from library
            Scripture scripture = library.GetRandomScripture();
            
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                
                // Display scripture with progress
                DisplayScripture(scripture);
                
                Console.WriteLine();
                Console.Write("Press enter to continue or type 'quit' to finish: ");
                
                string userInput = Console.ReadLine();
                
                if (userInput.ToLower() == "quit")
                {
                    continueProgram = false;
                    break;
                }
                
                // Hide some random words
                scripture.HideRandomWords(3);
            }
            
            if (continueProgram)
            {
                Console.Clear();
                DisplayScripture(scripture);
                Console.WriteLine();
                Console.WriteLine("Congratulations! You have hidden all the words!");
                Console.WriteLine();
                Console.Write("Would you like to practice another scripture? (yes/no): ");
                
                string response = Console.ReadLine();
                if (response.ToLower() != "yes" && response.ToLower() != "y")
                {
                    continueProgram = false;
                }
            }
        }
        
        Console.WriteLine("Thank you for using Scripture Memorizer. Keep studying!");
    }
    
    private static void DisplayScripture(Scripture scripture)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(scripture.GetDisplayText());
        Console.ResetColor();
        
        // Show progress
        int totalWords = scripture.GetTotalWordCount();
        int hiddenWords = scripture.GetHiddenWordCount();
        double percentage = (double)hiddenWords / totalWords * 100;
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Progress: {hiddenWords}/{totalWords} words hidden ({percentage:F1}%)");
        Console.ResetColor();
    }
}