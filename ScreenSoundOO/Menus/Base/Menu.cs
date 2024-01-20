using ScreenSoundOO.Models;

namespace ScreenSoundOO.Menus.Base;
internal class Menu
{
    public virtual void Exec(Dictionary<string, Band> registeredBands)
    {
        Console.Clear();
    }

    public static void WriteAndWait(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }

    public static void PrintFunctionName(string functionName)
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
}
