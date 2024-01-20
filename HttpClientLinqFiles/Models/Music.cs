using System.Text.Json.Serialization;

namespace HttpClientLinqFiles.Models;
internal class Music
{
    private static readonly string[] KeyMap = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

    [JsonPropertyName("song")]
    public string? Name { get; set; }
    [JsonPropertyName("artist")]
    public string? Artist { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Length { get; set; }
    [JsonPropertyName("genre")]
    public string? Genre { get; set; }
    [JsonPropertyName("key")]
    public int? Key { get; set; }
    public string Tone { 
        get 
        {
            return KeyMap[Key.GetValueOrDefault()];    
        } 
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Artist: {Artist}");
        Console.WriteLine($"Music: {Name}");
        Console.WriteLine($"Length: {Length/1000} seconds");
        Console.WriteLine($"Genre: {Genre}");
        if (Key < 12 && Key >= 0) Console.WriteLine($"Key: {Tone}");
    }
}
