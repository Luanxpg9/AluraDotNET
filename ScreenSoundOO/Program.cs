using ScreenSoundOO.Menus;
using ScreenSoundOO.Menus.Base;
using ScreenSoundOO.Models;
using OpenAI_API;

#region Bands

var gpt_key = Environment.GetEnvironmentVariable("GPT_KEY", EnvironmentVariableTarget.Machine) 
    ?? throw new Exception("GPT API does not exists in environment variables");

var client = new OpenAIAPI(gpt_key);
var chat = client.Chat.CreateConversation();

chat.AppendSystemMessage($"Resume the band Linkin Park in 250 charaters or less.");

string bandResumeLP = chat.GetResponseFromChatbotAsync().Result;

Band linkinPark = new()
{
    Name = "Linkin Park",
    Resume = bandResumeLP
};

Music music1 = new(linkinPark) {Name = "Don't Stay", Length = 188 };

Music music2 = new(linkinPark, "Somewhere I Belong", 214, true);

Album album = new("Meteora");

album.AddMusic(music1);
album.AddMusic(music2);

//album.ListMusics();

linkinPark.AddAlbum(album);

//linkinPark.ListAlbums();

#endregion

#region Podcast
/*
var episode = new Episode("Everything about Computer Science", 1);
episode.AddGuest("John Cena");

var episode2 = new Episode("How to use C#", 2);

var podcast = new Podcast("The Programmer Show", "A very good programmer");

podcast.AddEpisode(episode);
podcast.AddEpisode(episode2);

podcast.ShowDetails();
*/
#endregion

chat.AppendSystemMessage($"Resume the band Queen in 250 charaters or less.");

string bandResumeQueen = chat.GetResponseFromChatbotAsync().Result;

Band queen = new() 
{ 
    Name = "Queen",
    Resume = bandResumeQueen
};

queen.AddRating(10);
queen.AddRating(9);
linkinPark.AddRating(10);
linkinPark.AddRating(9);
linkinPark.AddRating(8);

Dictionary<string, Band> registeredBands = new()
{
    {"Linkin Park", linkinPark },
    {"Queen", queen }
 };

// Initializing menuOptions mapping
Dictionary<int, Menu> menuOptions = new()
{
    { 1, new RegisterBand() },
    { 2, new ListBands() },
    { 3, new RateBand() },
    { 4, new ShowBandRating() },
    { 5, new ShowDetails() },
    { 6, new RateAlbum() }
};


void PrintWelcomeMessage()
{
    Console.Clear();
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

void MenuOptions()
{
    PrintWelcomeMessage();
    Console.WriteLine("\n\tType 1 to register a band");
    Console.WriteLine("\tType 2 to show all bands");
    Console.WriteLine("\tType 3 to rate a band");
    Console.WriteLine("\tType 4 to show band rating");
    Console.WriteLine("\tType 5 to show band details");
    Console.WriteLine("\tType 6 to rate an album");
    Console.WriteLine("\tType 0 to logout");

    Console.Write("\nType your option: ");
    string? choosenOption = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(choosenOption))
    {
        Console.WriteLine("Invalid Option, exiting program!");
        return;
    }

    int parsedOption = int.Parse(choosenOption);

    if (!menuOptions.ContainsKey(parsedOption))
    {
        Console.WriteLine("Byee ;)");
        return;
    }

    Menu menu = menuOptions[parsedOption];

    menu.Exec(registeredBands);
    MenuOptions();
}

MenuOptions();