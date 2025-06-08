using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Bake a Cake", "Chef John", 300);
        video1.AddComment(new Comment("Alice", "Yummy!"));
        video1.AddComment(new Comment("Bob", "This helped a lot!"));
        video1.AddComment(new Comment("Charlie", "I burned it. Oops."));
        videos.Add(video1);

        Video video2 = new Video("Intro to Programming", "Jane Doe", 600);
        video2.AddComment(new Comment("Dave", "Very clear explanation."));
        video2.AddComment(new Comment("Eva", "Thanks for this!"));
        video2.AddComment(new Comment("Frank", "Loved the visuals."));
        videos.Add(video2);

        Video video3 = new Video("Yoga for Beginners", "YogaWithAva", 900);
        video3.AddComment(new Comment("George", "Namaste."));
        video3.AddComment(new Comment("Helen", "Felt so relaxed."));
        video3.AddComment(new Comment("Ivy", "This is perfect."));
        videos.Add(video3);

        // Display info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
