namespace ScreenSoundOO.Models;
internal class Podcast
{
    public Podcast(string name, string host = "")
    {
        Name = name;
        Host = host;
    }

    public string Host { get; set; }
    public string Name { get; init; }
    private List<Episode> Episodes { get; } = new();
    public int TotalEpisodes => Episodes.Count;

    public void AddEpisode(Episode episode) => Episodes.Add(episode);

    public void ShowDetails()
    {
        Console.WriteLine($"{Name} presented by {Host}\n");
        Console.WriteLine($"Total episodes {TotalEpisodes}\n");

        foreach (var episode in Episodes.OrderBy(e => e.Number))
        {
            Console.WriteLine($"\tEpisode {episode.Number}: {episode.Title}");
           

            if (episode.Guests.Any())
            {
                Console.WriteLine($"\tSpecial guests: ");
                episode.Guests.ForEach(g => Console.WriteLine("\t\t\t" + g));
            }
            Console.WriteLine();
        }
    }
}
