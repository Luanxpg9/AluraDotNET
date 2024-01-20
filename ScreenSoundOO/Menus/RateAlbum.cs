using ScreenSoundOO.Menus.Base;
using ScreenSoundOO.Models;

namespace ScreenSoundOO.Menus;
internal class RateAlbum : Menu
{
    public override void Exec(Dictionary<string, Band> registeredBands)
    {
        base.Exec(registeredBands);
        PrintFunctionName("Rate an album");

        Console.Write("Search band: ");
        var searchBand = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(searchBand))
        {
            WriteAndWait("Invalid band name!");
            return;
        }

        searchBand = searchBand.Trim();

        if (!registeredBands.ContainsKey(searchBand))
        {
            WriteAndWait("Band not found, returning to Menu");
            return;
        }

        var foundBand = registeredBands[searchBand];
        Console.WriteLine($"Found band: {foundBand.Name}");

        Console.Write("Type a band name: ");
        string albumName = Console.ReadLine()!;
        albumName = albumName.Trim();

        if (string.IsNullOrEmpty(albumName))
        {
            WriteAndWait("Invalid album name! Returning to Menu");
            return;
        }

        var foundAlbum = foundBand.Albums.Find(x => x.Name.Trim().ToLower().Equals(albumName.ToLower()));

        if (foundAlbum == null)
        {
            WriteAndWait($"This band doesnt contain an album named {albumName}");
            return;
        }

        Console.WriteLine($"\tFound album: {foundAlbum.Name}");


        Console.Write("Type your rating: ");
        var rating = Console.ReadLine();

        // Is Number
        if (string.IsNullOrEmpty(rating))
        {
            Console.WriteLine("Invalid rating... returning to menu!");
            Thread.Sleep(2000);
            return;
        }

        var ratingInt = int.Parse(rating);
        foundAlbum.AddRating(ratingInt);
        WriteAndWait($"Your rating of {ratingInt} has been add to album {foundAlbum.Name}");
    }
}
