using System;
using System.Collections.Generic;

/// <summary>
/// Manages a library of scriptures for the memorization program
/// This class exceeds requirements by providing multiple scriptures
/// </summary>
public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;
    
    /// <summary>
    /// Constructor that initializes the scripture library
    /// </summary>
    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
        InitializeScriptures();
    }
    
    /// <summary>
    /// Initializes the library with a collection of scriptures
    /// </summary>
    private void InitializeScriptures()
    {
        // Faith scriptures
        _scriptures.Add(new Scripture(
            new Reference("Alma", 32, 21),
            "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."
        ));
        
        _scriptures.Add(new Scripture(
            new Reference("Ether", 12, 6),
            "And now, I, Moroni, would speak somewhat concerning these things; I would show unto the world that faith is things which are hoped for and not seen; wherefore, dispute not because ye see not, for ye receive no witness until after the trial of your faith."
        ));
        
        // Hope and comfort scriptures
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ));
        
        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
        ));
        
        // Service and charity scriptures
        _scriptures.Add(new Scripture(
            new Reference("1 Corinthians", 13, 13),
            "And now abideth faith, hope, charity, these three; but the greatest of these is charity."
        ));
        
        _scriptures.Add(new Scripture(
            new Reference("Mosiah", 2, 17),
            "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
        ));
        
        // Strength and courage scriptures
        _scriptures.Add(new Scripture(
            new Reference("Joshua", 1, 9),
            "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."
        ));
        
        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."
        ));
        
        // Wisdom and knowledge scriptures
        _scriptures.Add(new Scripture(
            new Reference("2 Nephi", 32, 3),
            "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do."
        ));
        
        _scriptures.Add(new Scripture(
            new Reference("James", 1, 5, 6),
            "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering."
        ));
    }
    
    /// <summary>
    /// Gets a random scripture from the library
    /// </summary>
    /// <returns>A randomly selected scripture</returns>
    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            throw new InvalidOperationException("No scriptures available in the library.");
        }
        
        int randomIndex = _random.Next(_scriptures.Count);
        Scripture selectedScripture = _scriptures[randomIndex];
        
        // Create a new copy to avoid modifying the original
        return new Scripture(selectedScripture.GetReference(), GetScriptureText(selectedScripture));
    }
    
    /// <summary>
    /// Gets all available scriptures in the library
    /// </summary>
    /// <returns>List of all scriptures</returns>
    public List<Scripture> GetAllScriptures()
    {
        return new List<Scripture>(_scriptures);
    }
    
    /// <summary>
    /// Gets the number of scriptures in the library
    /// </summary>
    /// <returns>Number of scriptures</returns>
    public int GetScriptureCount()
    {
        return _scriptures.Count;
    }
    
    /// <summary>
    /// Adds a new scripture to the library
    /// </summary>
    /// <param name="scripture">Scripture to add</param>
    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }
    
    /// <summary>
    /// Helper method to extract scripture text from a scripture object
    /// This is a workaround since we don't have direct access to the text
    /// </summary>
    /// <param name="scripture">Scripture object</param>
    /// <returns>Scripture text</returns>
    private string GetScriptureText(Scripture scripture)
    {
        // This is a simple way to extract the text by getting the display text
        // and removing the reference portion
        string displayText = scripture.GetDisplayText();
        string referenceText = scripture.GetReference().GetDisplayText();
        return displayText.Substring(referenceText.Length + 1); // +1 for the space
    }
}