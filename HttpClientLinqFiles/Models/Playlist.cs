using System.Text.Json;

namespace HttpClientLinqFiles.Models;
internal class Playlist
{
    public string Name { get; set; }
    public List<Music> MusicList { get; } = new List<Music>();

    public Playlist(string playlistName)
    {
        Name = playlistName;
    }

    public bool AddMusic(Music music)
    {

        if (MusicList.Exists(m => m.Name != null && m.Name.Trim().Equals(music.Name))) 
            return false;

        MusicList.Add(music);
        return true;
    }

    public void AddRange(IEnumerable<Music> musics)
    {
        MusicList.AddRange(musics);
    }

    public bool SavePlaylist()
    {
        string json = JsonSerializer.Serialize(
            new { 
                name = Name,
                musics = MusicList
            });

        string filename = $"playlist-{Name.Trim().ToLower()}.json";

        File.WriteAllText(filename, json);

        return true;
    }

    public void ShowPlaylist()
    {
        Console.WriteLine($"Playlist: {Name}");
        MusicList.ForEach(music => Console.WriteLine($"\t ->'{music.Name}' by '{music.Artist}'"));
    }
}
