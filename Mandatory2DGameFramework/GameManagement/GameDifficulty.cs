namespace Mandatory2DGameFramework.GameManagement;

public class GameDifficulty
{
    public Difficulty Current { get; private set; } = Difficulty.Normal;

    public enum Difficulty
    {
        Easy = 0,
        Normal = 1,
        Hard = 2,
        VeryHard = 3
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        Current = difficulty;
    }

    public void SetDifficulty(int difficultyId)
    {
        Current = (Difficulty)difficultyId;
    }

    public override string ToString()
    {
        return $"{{{nameof(Current)} = {Current}}}"; ;
    }
}
