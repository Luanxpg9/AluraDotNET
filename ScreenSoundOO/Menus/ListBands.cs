using ScreenSoundOO.Menus.Base;
using ScreenSoundOO.Models;

namespace ScreenSoundOO.Menus;
internal class ListBands : Menu
{
    public override void Exec(Dictionary<string, Band> registeredBands)
    {
       base.Exec(registeredBands);
       PrintFunctionName("Band List");

       for (int i = 0; i < registeredBands.Count; i++)
       {
           Console.WriteLine(i + 1 + ">> " + registeredBands.ElementAt(i).Key);
       }

       Console.ReadKey();
    }
}
