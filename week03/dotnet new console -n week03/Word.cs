using System.Linq;

/// <summary>
/// Represents a single word in a scripture with the ability to hide/show it
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;
    
    /// <summary>
    /// Constructor for a word
    /// </summary>
    /// <param name="text">The text of the word</param>
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    
    /// <summary>
    /// Hides the word
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }
    
    /// <summary>
    /// Shows the word (makes it visible)
    /// </summary>
    public void Show()
    {
        _isHidden = false;
    }
    
    /// <summary>
    /// Checks if the word is currently hidden
    /// </summary>
    /// <returns>True if hidden, false if visible</returns>
    public bool IsHidden()
    {
        return _isHidden;
    }
    
    /// <summary>
    /// Gets the display text for the word (either the actual word or underscores)
    /// </summary>
    /// <returns>Display text for the word</returns>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace each letter with an underscore, preserve punctuation
            return new string(_text.Select(c => char.IsLetter(c) ? '_' : c).ToArray());
        }
        else
        {
            return _text;
        }
    }
    
    /// <summary>
    /// Gets the original text of the word
    /// </summary>
    /// <returns>Original word text</returns>
    public string GetText()
    {
        return _text;
    }
    
    /// <summary>
    /// Gets the length of the word (number of characters)
    /// </summary>
    /// <returns>Word length</returns>
    public int GetLength()
    {
        return _text.Length;
    }
}