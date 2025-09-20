/// <summary>
/// Represents a scripture reference with book, chapter, and verse information
/// Supports both single verses and verse ranges
/// </summary>
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    
    /// <summary>
    /// Constructor for single verse reference
    /// </summary>
    /// <param name="book">Book name (e.g., "John", "1 Nephi")</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="verse">Verse number</param>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse; // Single verse, so end verse is same as start verse
    }
    
    /// <summary>
    /// Constructor for verse range reference
    /// </summary>
    /// <param name="book">Book name (e.g., "Proverbs", "2 Nephi")</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="startVerse">Starting verse number</param>
    /// <param name="endVerse">Ending verse number</param>
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }
    
    /// <summary>
    /// Gets the formatted display text for the reference
    /// </summary>
    /// <returns>Formatted reference string</returns>
    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            // Single verse: "John 3:16"
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            // Verse range: "Proverbs 3:5-6"
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
    
    /// <summary>
    /// Gets the book name
    /// </summary>
    /// <returns>Book name</returns>
    public string GetBook()
    {
        return _book;
    }
    
    /// <summary>
    /// Gets the chapter number
    /// </summary>
    /// <returns>Chapter number</returns>
    public int GetChapter()
    {
        return _chapter;
    }
    
    /// <summary>
    /// Gets the starting verse number
    /// </summary>
    /// <returns>Starting verse number</returns>
    public int GetVerse()
    {
        return _verse;
    }
    
    /// <summary>
    /// Gets the ending verse number
    /// </summary>
    /// <returns>Ending verse number</returns>
    public int GetEndVerse()
    {
        return _endVerse;
    }
    
    /// <summary>
    /// Checks if this reference represents a verse range
    /// </summary>
    /// <returns>True if verse range, false if single verse</returns>
    public bool IsVerseRange()
    {
        return _verse != _endVerse;
    }
}