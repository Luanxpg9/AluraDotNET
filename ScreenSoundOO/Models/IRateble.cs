namespace ScreenSoundOO.Models;
internal interface IRateble
{
    void AddRating(int rate);
    double AverageRating { get; }
}
