using ScreenSoundOO.Menus.Base;
using ScreenSoundOO.Models;

namespace ScreenSoundOO.Menus;
internal class ShowDetails : Menu
{
    public override void Exec(Dictionary<string, Band> registeredBands)
    {
        base.Exec(registeredBands);
        PrintFunctionName("Show Band Details");
        Console.WriteLine("Type the band name you wish to know better: ");
        var bandName = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(bandName))
        {
            Console.WriteLine("Invalid band name");
            Console.ReadKey();
            return;
        }

        if (!registeredBands.ContainsKey(bandName))
        {
            Console.WriteLine("This band is not registered! please register and try again!");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        PrintFunctionName("Show Band Details");

        var band = registeredBands[bandName];

        Console.WriteLine($"{band.Name}: \n");
        Console.WriteLine($"Average band rating {band.AverageRating}\n");
        Console.WriteLine($"Resume: {band.Resume}");

        if (band.Albums.Any()) 
        {
            Console.WriteLine($"\tRecorded Albums: {band.Albums.Count}");

            band.Albums.ForEach(a => Console.WriteLine($"\t\tAlbum {a.Name} has a duration of {a.Duration/60} minutes"));
        }

        Console.ReadKey();
    }
}
