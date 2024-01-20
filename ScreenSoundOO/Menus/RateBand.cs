using ScreenSoundOO.Menus.Base;
using ScreenSoundOO.Models;

namespace ScreenSoundOO.Menus;
internal class RateBand : Menu
{
    public override void Exec(Dictionary<string, Band> registeredBands)
    {
        base.Exec(registeredBands);
        PrintFunctionName("Rate a band");

        Console.Write("Search band: ");
        var searchBand = Console.ReadLine();

        if (String.IsNullOrEmpty(searchBand))
        {
            Console.WriteLine("Invalide band name");
            return;
        }
        
        searchBand = searchBand.Trim();
        
        if (!registeredBands.ContainsKey(searchBand))
        {
            // Band not found, will the user register it?
            Console.WriteLine("Your band was not found. Would you like to register?\n1- Register\t 2- Let go");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid answer, letting go.");
                return;
            }

            if (input.StartsWith('1'))
            {
                registeredBands.Add(searchBand.Trim(), new());
                Console.WriteLine("Band sucessfully registered");
                return;
            }
        }

        
        Console.WriteLine($"Found band: {searchBand}");
        Console.Write("Type your rating: ");
        var rating = Console.ReadLine();

        // Is Number
        if (string.IsNullOrEmpty(rating))
        {
            Console.WriteLine("Please Type a valid rating");
            return;
        }

        var ratingInt = int.Parse(rating);
        registeredBands[searchBand].AddRating(ratingInt);
        Console.WriteLine("Your rating has been add");
        Console.ReadKey();
    }
}
