namespace Mandatory2DGameFramework.GameManagement;

public class GameDifficulty
{
    public Difficulty CurrentDifficulty { get; private set; }

    public enum Difficulty
    {
        Easy = 0,
        Normal = 1,
        Hard = 2,
        VeryHard = 3
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
    }

    public void SetDifficulty(int difficultyId)
    {
        CurrentDifficulty = (Difficulty)difficultyId;
    }
}
