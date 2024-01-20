using HttpClientLinqFiles.Filters;
using HttpClientLinqFiles.Models;
using System.Text.Json;

// Using HttpClient
using (HttpClient client = new())
{
    try
    {
        string answer = await client.GetStringAsync(
        "https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        #region Deserializing and Serializing
        List<Music> musics = JsonSerializer.Deserialize<List<Music>>(answer)!;

        string musicJson = JsonSerializer.Serialize(musics);
        #endregion

        #region Linq functions
        //LinqOrder.GetOrderedArtists(musics);

        //LinqOrder.FilterByGenre(musics, "pop").ToList();

        //LinqOrder.GetSongsByArtist(musics, "Paramore");

        //LinqOrder.GetSongsByTone(musics, "C#");
        #endregion

        #region Take, AddRange and Shuffle
        var newPlaylist = new Playlist("Favorite Songs");
        var shuffledList = musics.OrderBy(m => Guid.NewGuid()).ToList();
        newPlaylist.AddRange(shuffledList.Take(50));

        newPlaylist.ShowPlaylist();

        newPlaylist.SavePlaylist();
        #endregion

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error while trying to fetch: {ex.Message}");
    }
}