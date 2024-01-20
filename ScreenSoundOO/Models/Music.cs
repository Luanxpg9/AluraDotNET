namespace ScreenSoundOO.Models;
internal class Music
{
    public Band Artist { get; }
    public string Name { get; init; } = string.Empty;
    /// <summary>
    /// Length  in seconds
    /// </summary>
    public int Length { get; set; }
    public bool Available { get; set; } = false;

    public Music(Band band, int length = 0, bool available = false)
    {
        Artist = band;
        Length = length;
        Available = available;
    }

    public Music(Band band, string name, int length = 0, bool available = false)
    {
        Artist = band;
        Name = name;
        Length = length;
        Available = available;
    }

    public string Description => $"The music {Name} was written by {Artist} and has a length of {Length} seconds";

    public void ToggleAvailable() => Available = !Available;


    public void ShowDatasheet()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Artist: {Artist}");
        Console.WriteLine($"Length: {Length / 60} minutes and {Length % 60} seconds");
        Console.WriteLine(Available ? "Available" : "Not Available");
    }
}
