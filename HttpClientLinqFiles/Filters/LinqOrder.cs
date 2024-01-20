using HttpClientLinqFiles.Models;

namespace HttpClientLinqFiles.Filters;
internal class LinqOrder
{
    public static List<Music> FilterByGenre(List<Music> musics, string genre)
    {
        var filteredMusics = musics.Where(m => 
            !string.IsNullOrEmpty(m.Genre) && m.Genre.Trim()
                                                     .ToLower()
                                                     .Contains(genre.Trim().ToLower()))
                                                     .ToList();
        foreach (var music in filteredMusics)
        {
            music.ShowDetails();
        }


        return filteredMusics;
    }

    public static List<string?> GetOrderedArtists(List<Music> musics)
    {
        var orderedArtists = musics.OrderBy(m => m.Artist).Select(m => m.Artist).Distinct();

        foreach (var artist in orderedArtists)
        {
            Console.WriteLine($"- {artist}");
        }

        return orderedArtists.ToList();
    }

    public static List<string?> GetSongsByArtist(List<Music> musics, string artist)
    {
        var orderedSongs = musics.Where(m => !String.IsNullOrEmpty(m.Artist)
        && m.Artist.Trim().ToLower().Equals(artist.Trim().ToLower()))
            .OrderBy(m => m.Name);

        foreach (var song in orderedSongs)
        {
            song.ShowDetails();
        }

        return orderedSongs.Select(m => m.Name).ToList()!;
    }

    public static List<string?> GetSongsByTone(List<Music> musics, string tone)
    {
        var orderedSongs = musics.Where(m => m.Tone.Equals(tone.Trim()));

        foreach (var song in orderedSongs)
        {
            song.ShowDetails();
        }

        return orderedSongs.Select(m => m.Name).ToList()!;
    }

}
