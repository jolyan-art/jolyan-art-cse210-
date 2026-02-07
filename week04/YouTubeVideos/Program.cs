using System;
using System.Collections.Generic;

// Comment class
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video class
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds

    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
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

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learn C# in 10 Minutes", "Code Academy", 600);
        Video video2 = new Video("Understanding Abstraction", "Tech Simplified", 540);
        Video video3 = new Video("Top Programming Tips", "Dev World", 480);

        // Add comments to video 1
        video1.AddComment(new Comment("John", "Very helpful tutorial!"));
        video1.AddComment(new Comment("Mary", "I finally understand C#!"));
        video1.AddComment(new Comment("Alex", "Great explanation."));

        // Add comments to video 2
        video2.AddComment(new Comment("Sarah", "Abstraction makes sense now."));
        video2.AddComment(new Comment("James", "Clear and simple."));
        video2.AddComment(new Comment("Linda", "Excellent examples."));

        // Add comments to video 3
        video3.AddComment(new Comment("Brian", "Awesome tips!"));
        video3.AddComment(new Comment("Emma", "Loved this video."));
        video3.AddComment(new Comment("Chris", "Very informative."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
