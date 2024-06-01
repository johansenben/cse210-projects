class VideoManager
{
    private List<Video> _videos = new List<Video>();

    public VideoManager()
    {
        AddVideo(new Video("Title #1", "Author #1", 100, "Description #1"));
        _videos[0].AddComment(new Comment("Commenter Name #1-1", "Comment #1-1 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));
        _videos[0].AddComment(new Comment("Commenter Name #1-2", "Comment #1-2 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));
        _videos[0].AddComment(new Comment("Commenter Name #1-3", "Comment #1-3 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));

        AddVideo(new Video("Title #2", "Author #2", 200, "Description #2"));
        _videos[1].AddComment(new Comment("Commenter Name #2-1", "Comment #2-1 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));
        _videos[1].AddComment(new Comment("Commenter Name #2-2", "Comment #2-2 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));
        _videos[1].AddComment(new Comment("Commenter Name #2-3", "Comment #2-3 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));

        AddVideo(new Video("Title #3", "Author #3", 300, "Description #3"));
        _videos[2].AddComment(new Comment("Commenter Name #3-1", "Comment #3-1 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));
        _videos[2].AddComment(new Comment("Commenter Name #3-2", "Comment #3-2 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));
        _videos[2].AddComment(new Comment("Commenter Name #3-3", "Comment #3-3 Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero officiis, molestias modi dolore ad a reprehenderit earum iste nemo. Assumenda."));
    }

    public void HandleIO()
    {
        bool brk = false;
        while (!brk)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. View Videos");
            Console.WriteLine("2. Find Longest Video");
            Console.WriteLine("3. Find Shortest Video");
            Console.WriteLine("4. Find Comment That Contains Specific Text");
            Console.WriteLine("5. Quit (Default)");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Display();
                    break;
                case "2":
                    Video longestVideo = FindLongestVideo();
                    Console.WriteLine("Longest Video:");
                    longestVideo.DisplayHeader();
                    break;
                case "3":
                    Video shortestVideo = FindShortestVideo();
                    Console.WriteLine("Shortest Video:");
                    shortestVideo.DisplayHeader();
                    break;
                case "4":
                    Console.WriteLine("What string of text do you want to search for?");
                    string text = Console.ReadLine();
                    List<(Video, List<Comment>)> commentsFound = FindCommentsWithString(text);
                    foreach ((Video video, List<Comment> comments) in commentsFound)
                    {
                        video.DisplayHeader();
                        foreach (Comment comment in comments)
                        {
                            comment.Display();
                        }
                    }
                    break;
                default:
                    brk = true;
                    break;
            }
            Console.WriteLine();
        }
    }
    private void AddVideo(Video video)
    {
        _videos.Add(video);
    }
    public void Display()
    {
        foreach (Video video in _videos)
        {
            video.Display();
        }
    }

    public Video FindLongestVideo()
    {
        Video longestVideo = null;
        int longestVideoSeconds = 0;
        foreach (Video video in _videos)
        {
            if (video.GetSeconds() > longestVideoSeconds)
            {
                longestVideoSeconds = video.GetSeconds();
                longestVideo = video;
            }
        }

        return longestVideo;
    }
    public Video FindShortestVideo()
    {
        Video shortestVideo = null;
        int? shortestVideoSeconds = null;
        foreach (Video video in _videos)
        {
            if (shortestVideoSeconds == null || video.GetSeconds() < shortestVideoSeconds)
            {
                shortestVideoSeconds = video.GetSeconds();
                shortestVideo = video;
            }
        }
        return shortestVideo;
    }
    public List<(Video, List<Comment>)> FindCommentsWithString(string str)
    {
        List<(Video, List<Comment>)> found = new List<(Video, List<Comment>)>();
        foreach (Video video in _videos)
        {
            found.Add((video, video.SearchForComment(str)));
        }
        return found;
    }
}