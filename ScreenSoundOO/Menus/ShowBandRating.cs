using ScreenSoundOO.Menus.Base;
using ScreenSoundOO.Models;

namespace ScreenSoundOO.Menus;
internal class ShowBandRating : Menu
{
    public override void Exec(Dictionary<string, Band> registeredBands)
    {
        base.Exec(registeredBands);
        PrintFunctionName("Bands ratings");

        foreach (var band in registeredBands.OrderByDescending(b => b.Value.AverageRating))
        {
            Console.WriteLine($"{band.Key} >> {band.Value.AverageRating:0.00}");
            
            if (band.Value.Albums.Count > 0)
            {
                Console.WriteLine("\tAlbums: ");
                foreach (var album in band.Value.Albums)
                {
                    Console.WriteLine($"\t\t{album.Name} >> {album.AverageRating}");
                }
            }
            
        }

        Console.ReadKey();
    }
}
