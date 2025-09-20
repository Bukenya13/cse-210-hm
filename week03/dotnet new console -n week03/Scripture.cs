using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a scripture with reference and text, managing word hiding functionality
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;
    
    /// <summary>
    /// Constructor for single verse scripture
    /// </summary>
    /// <param name="reference">Scripture reference</param>
    /// <param name="text">Scripture text</param>
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();
        
        // Split text into words and create Word objects
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }
    
    /// <summary>
    /// Gets the complete display text including reference and scripture text
    /// </summary>
    /// <returns>Formatted scripture display text</returns>
    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {scriptureText}";
    }
    
    /// <summary>
    /// Hides a specified number of random words that are still visible
    /// </summary>
    /// <param name="numberToHide">Number of words to hide</param>
    public void HideRandomWords(int numberToHide)
    {
        // Get list of visible words
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        
        // Don't try to hide more words than are available
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
        
        // Randomly select and hide words
        for (int i = 0; i < wordsToHide; i++)
        {
            if (visibleWords.Count > 0)
            {
                int randomIndex = _random.Next(visibleWords.Count);
                Word selectedWord = visibleWords[randomIndex];
                selectedWord.Hide();
                visibleWords.RemoveAt(randomIndex);
            }
        }
    }
    
    /// <summary>
    /// Checks if all words in the scripture are hidden
    /// </summary>
    /// <returns>True if all words are hidden, false otherwise</returns>
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
    
    /// <summary>
    /// Gets the total number of words in the scripture
    /// </summary>
    /// <returns>Total word count</returns>
    public int GetTotalWordCount()
    {
        return _words.Count;
    }
    
    /// <summary>
    /// Gets the number of hidden words in the scripture
    /// </summary>
    /// <returns>Hidden word count</returns>
    public int GetHiddenWordCount()
    {
        return _words.Count(word => word.IsHidden());
    }
    
    /// <summary>
    /// Gets the reference for this scripture
    /// </summary>
    /// <returns>Scripture reference</returns>
    public Reference GetReference()
    {
        return _reference;
    }
}