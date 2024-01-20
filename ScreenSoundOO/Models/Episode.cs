namespace ScreenSoundOO.Models;
internal class Episode
{
    public Episode(string title, int number)
    {
        Title = title;
        Number = number;
    }

    public string Title { get; set; }
    public string Description { get; set; } = String.Empty;
    public int Number { get; init; }
    public int Duration { get; set; }
    public List<string> Guests { get; } = new();

    public void AddGuest(string guest) => Guests.Add(guest);

    public override string ToString()
    {
        var objDescription = $"Title: {Title}\nEpisode number: {Number}\n" +
            $"Length of Episode: {Duration / 60} minutes and {Duration % 60} seconds";

        return objDescription;
    }
}
