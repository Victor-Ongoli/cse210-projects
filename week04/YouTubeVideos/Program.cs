// using System;

// class Program
// {
    // static void Main(string[] args)
    // {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
    // }
// }



using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Bake Sourdough Bread", "Chef Amara", 612);
        video1.AddComment(new Comment("Liam K.", "This finally worked for me, thank you!"));
        video1.AddComment(new Comment("Priya S.", "Can I use whole wheat flour instead?"));
        video1.AddComment(new Comment("Derek O.", "Great pacing, easy to follow."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("C# Abstraction Explained", "CodeWithVictor", 845);
        video2.AddComment(new Comment("Grace M.", "This cleared up so much confusion, thanks!"));
        video2.AddComment(new Comment("Tunde A.", "Could you do a follow-up on encapsulation?"));
        video2.AddComment(new Comment("Hannah R.", "The Video/Comment example made it click."));
        video2.AddComment(new Comment("Samuel N.", "Subscribed, looking forward to more!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Nairobi Street Food Tour", "Wanjiru Explores", 924);
        video3.AddComment(new Comment("Aiden F.", "Now I'm hungry, great video!"));
        video3.AddComment(new Comment("Zanele P.", "That mutura stall looks amazing."));
        video3.AddComment(new Comment("Ivan T.", "Adding this to my travel list."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Beginner Guitar Chords", "Strum School", 530);
        video4.AddComment(new Comment("Naledi B.", "Finally got my fingers to cooperate!"));
        video4.AddComment(new Comment("Kwame D.", "Slow it down a bit more for beginners maybe?"));
        video4.AddComment(new Comment("Ruth C.", "Best explanation of barre chords I've seen."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}