// Screen Sound
Dictionary<string, List<int>> registeredBands = new()
{
    { "U2", new List<int>() { 10, 8, 7 } },
    { "Linkin Park", new() { 10, 9, 8 } }
};

void PrintWelcomeMessage()
{
    string projectTitle = @"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";
    string welcomeMessage = "Welcome to screen sound";

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(projectTitle);
    Console.WriteLine('\n');
    Console.WriteLine(welcomeMessage);


    Console.ForegroundColor = ConsoleColor.White;
}
void PrintFunctionName(string functionName)
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Green;
    string asterisks = String.Empty;
    asterisks = asterisks.PadLeft(functionName.Length, '*');

    Console.WriteLine(asterisks);
    Console.WriteLine(functionName);
    Console.WriteLine(asterisks + '\n');

    Console.ForegroundColor = ConsoleColor.White;
}
int ValidateMenuOptions(string? choosenOption)
{
    if (int.TryParse(choosenOption, out int givenNumber) && givenNumber < 5 && givenNumber >= 0)
        return givenNumber;

    return -1;
}
void BandRegister()
{
    PrintFunctionName("Band Register");

    Console.Write("Type band name: ");
    string? bandName = Console.ReadLine();
    Console.WriteLine($"The band was registered sucessfully with the name {bandName}");

    if (bandName != null)
    {
        bandName = bandName.Trim();

        if (registeredBands.Keys.Any(x => x.ToLower().Equals(bandName.ToLower())))
        {
            Console.WriteLine("Band already registered");
        }
        else
        {
            Console.WriteLine($"Sucessfully registered the band {bandName}");
            registeredBands.Add(bandName, new List<int>());
        }
    }

    Thread.Sleep(1000);
    MenuOptions();
}
void RateBand()
{
    PrintFunctionName("Rate a band");

    Console.Write("Search band: ");
    var searchBand = Console.ReadLine();

    if (String.IsNullOrEmpty(searchBand))
    {
        Console.WriteLine("Invalide band name");
        MenuOptions();
    }
    else
    {
        searchBand = searchBand.Trim();

        if (registeredBands.ContainsKey(searchBand))
        {
            Console.WriteLine($"Found band: {searchBand}");
            Console.Write("Type your rating: ");
            var rating = Console.ReadLine();

            // Is Number
            if (string.IsNullOrEmpty(rating))
            {
                Console.WriteLine("Please Type a valid rating");
            }
            else
            {
                var ratingInt = int.Parse(rating);
                registeredBands[searchBand].Add(ratingInt);
                Console.WriteLine("Your rating has been add");
            }


        }
        else
        {
            // Band not found, will the user register it?
            Console.WriteLine("Your band was not found. Would you like to register?\n1- Register\t 2- Let go");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                if (input.StartsWith('1'))
                {
                    registeredBands.Add(searchBand.Trim(), new());
                    Console.WriteLine("Band sucessfully registered");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("Invalid answer, letting go.");
            }

        }
    }

    Thread.Sleep(1000);
    MenuOptions();
}
void ShowBandRating()
{
    PrintFunctionName("Bands ratings");

    var bandRatingList = new Dictionary<string, double>();

    foreach (var band in registeredBands)
    {
        var averageRating = band.Value.Average();
        bandRatingList.Add(band.Key, averageRating);
    }

    var orderedBand = bandRatingList.OrderByDescending(x => x.Value);

    foreach (var band in orderedBand)
    {
        Console.WriteLine($"{band.Key} >> {band.Value:0.00}");
    }

    Console.ReadKey();
    MenuOptions();
}
void ListRegisteredBands()
{
    PrintFunctionName("Band List");

    for (int i = 0; i < registeredBands.Count; i++)
    {

        Console.WriteLine(i + 1 + ">> " + registeredBands.ElementAt(i).Key);
    }

    Console.ReadKey();
    MenuOptions();
}
void MenuOptions()
{
    PrintWelcomeMessage();
    Console.WriteLine("\n\tType 1 to register a band");
    Console.WriteLine("\tType 2 to show all bands");
    Console.WriteLine("\tType 3 to rate a band");
    Console.WriteLine("\tType 4 to show band rating");
    Console.WriteLine("\tType 0 to logout");

    Console.Write("\nType your option: ");
    string? choosenOption = Console.ReadLine();

    int optionNumber = ValidateMenuOptions(choosenOption);

    switch (optionNumber)
    {
        case 1:
            BandRegister();
            break;

        case 2:
            ListRegisteredBands();
            break;
        case 3:
            RateBand();
            break;
        case 4:
            ShowBandRating();
            break;
        case 0:
            Console.WriteLine("Byee ;)");
            break;
        default:
            Console.WriteLine("Invalid option, closing program");
            break;
    }

}

MenuOptions();