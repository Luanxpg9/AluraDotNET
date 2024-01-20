namespace ScreenSoundOO.Models;
internal class Band : IRateble
{
    public string Name { get; set; } = String.Empty;
    public List<Rating> Ratings { get; set; } = new();
    public List<Album> Albums { get; set; } = new List<Album>();
    public string? Resume { get; set; }
    public double AverageRating
    {
        get
        {
            if (Ratings.Count == 0) return 0;
            else return Ratings.Average(r => r.Score);
        }
    }
    public void AddAlbum(Album album) => Albums.Add(album);

    public void AddRating(int rate) 
    {
        if (rate > 10) rate = 10;
        if (rate < 0) rate = 0;

        Ratings.Add(new Rating(rate));
    } 

    public void ListAlbums()
    {
        Console.WriteLine($"Recorded LP's of {Name}:");
        foreach (var album in Albums)
        {
            Console.WriteLine($"\t{album.Name} -> Total length {album.Duration}");
        }
    }
}
