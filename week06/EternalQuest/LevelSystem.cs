public class LevelSystem
{
    public static int CalculateLevel(int score)
    {
        return score / 1000 + 1;
    }

    public static string GetTitle(int level)
    {
        return level switch
        {
            <= 3 => "Novice",
            <= 5 => "Apprentice",
            <= 7 => "Seeker",
            <= 10 => "Champion",
            _ => "Legendary Hero"
        };
    }
}