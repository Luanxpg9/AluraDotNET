namespace ScreenSoundOO.Models;
internal class Album : IRateble
{
    public string Name { get; } = String.Empty;
    private List<Music> Musics = new();
    private List<Rating> Ratings = new();

    public Album(string name)
    {
        Name = name;
    }

    public int Duration => Musics.Sum(m => m.Length);

    public double AverageRating 
    { 
        get 
        {
            if (Ratings.Count == 0) return 0;
            else return Ratings.Average(r => r.Score);
        } 
    }

    public void AddMusic(Music music) => Musics.Add(music);

    public void ListMusics()
    {
        Console.WriteLine($"List of musics on {Name}\n");
        for (int i = 0; i < Musics.Count; i++)
        {
            Console.WriteLine($"\t{i}: {Musics[i].Name}\t\t- {Musics[i].Length / 60} minutes " +
                $"and {Musics[i].Length % 60} seconds");
        }

        Console.WriteLine($"\nTotal album length {Duration} seconds");
    }

    public void AddRating(int rate)
    {
        if (rate > 10) rate = 10;
        if (rate < 0) rate = 0;

        Ratings.Add(new Rating(rate));
    }
}
