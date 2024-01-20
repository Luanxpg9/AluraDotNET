namespace ScreenSoundOO.Models;
internal class Rating
{
    public int Score { get; }
    public Rating(int score)
    {
        Score = score;
    }

    public static Rating Parse(string rating)
    {
        int parsedRating = int.Parse(rating);
        return new Rating(parsedRating);
    }
}
