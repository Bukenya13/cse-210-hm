using System;
using System.Collections.Generic;

// (Removed duplicate Program class and Main method)

/// <summary>
/// YouTube Video Program - Foundation #1: Abstraction
/// CSE 210 - Week 04 Assignment
/// 
/// This program demonstrates abstraction by creating Video and Comment classes
/// to track YouTube videos and their associated comments.
/// </summary>
class Programc:
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Video Tracker");
        Console.WriteLine("=====================\n");

        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1: Programming Tutorial
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeAcademy Pro", 612);
        video1.AddComment(new Comment("Sarah Johnson", "Great tutorial! Very clear explanations."));
        video1.AddComment(new Comment("Mike Chen", "This helped me understand classes so much better!"));
        video1.AddComment(new Comment("Alex Rodriguez", "Could you do one on inheritance next?"));
        video1.AddComment(new Comment("Emma Wilson", "Perfect for beginners like me. Thank you!"));

        // Create Video 2: Cooking Video
        Video video2 = new Video("Perfect Chocolate Chip Cookies", "Baker's Kitchen", 845);
        video2.AddComment(new Comment("Lisa Martinez", "Made these yesterday and they were amazing!"));
        video2.AddComment(new Comment("David Thompson", "What temperature should the butter be?"));
        video2.AddComment(new Comment("Rachel Green", "My family loved these cookies!"));

        // Create Video 3: Travel Vlog
        Video video3 = new Video("Exploring Madagascar Wildlife", "Adventure Seeker", 1456);
        video3.AddComment(new Comment("Tom Anderson", "The lemurs are so cute! Adding this to my bucket list."));
        video3.AddComment(new Comment("Maria Gonzalez", "Your camera work is incredible. What equipment do you use?"));
        video3.AddComment(new Comment("James Smith", "Madagascar looks absolutely beautiful!"));
        video3.AddComment(new Comment("Anna Lee", "Thanks for showing the conservation efforts too."));

        // Create Video 4: Fitness Tutorial
        Video video4 = new Video("15-Minute Morning Yoga Flow", "Zen Fitness", 923);
        video4.AddComment(new Comment("Jennifer Brown", "Perfect way to start my day. Thanks!"));
        video4.AddComment(new Comment("Robert Kim", "Can you make one for evening relaxation?"));
        video4.AddComment(new Comment("Sophie Miller", "Love your teaching style!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds ({video.GetFormattedLength()})");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine();
            
            Console.WriteLine("Comments:");
            Console.WriteLine("---------");
            
            List<Comment> comments = video.GetComments();
            foreach (Comment comment in comments)
            {
                Console.WriteLine($"• {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
        }

        Console.WriteLine("Program completed successfully!");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

/// <summary>
/// Represents a comment on a YouTube video.
/// </summary>
public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetCommentText()
    {
        return _commentText;
    }
}

/// <summary>
/// Represents a YouTube video with comments.
/// </summary>
public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    public string GetFormattedLength()
    {
        int minutes = _lengthInSeconds / 60;
        int seconds = _lengthInSeconds % 60;
        return $"{minutes}m {seconds}s";
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}