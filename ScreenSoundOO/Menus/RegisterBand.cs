using OpenAI_API;
using ScreenSoundOO.Menus.Base;
using ScreenSoundOO.Models;

namespace ScreenSoundOO.Menus;
internal class RegisterBand : Menu
{
    public override void Exec(Dictionary<string, Band> registeredBands)
    {
        base.Exec(registeredBands);
        PrintFunctionName("Band Register");

        Console.Write("Type band name: ");
        string? bandName = Console.ReadLine();

        if (bandName == null) return;
        
        bandName = bandName.Trim();

        if (registeredBands.ContainsKey(bandName))
        {
            Console.WriteLine("Band already registered");
            Console.ReadKey();
            return;
        }

        var client = new OpenAIAPI(Environment.GetEnvironmentVariable("GTP_KEY"));
        var chat = client.Chat.CreateConversation();

        chat.AppendSystemMessage($"Resume the band {bandName} in 250 charaters or less.");

        string bandResume = chat.GetResponseFromChatbotAsync().Result;

        Console.WriteLine($"Sucessfully registered the band {bandName}");
        registeredBands.Add(bandName, new Band() { Name = bandName, Resume = bandResume });

        Console.ReadKey();
    }
}
