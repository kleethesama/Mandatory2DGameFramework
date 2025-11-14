namespace Mandatory2DGameFramework.GameManagement;

public sealed class GameDifficulty
{
    private static readonly Lazy<GameDifficulty> _instance = new(() => new GameDifficulty());

    public static GameDifficulty Instance { get => _instance.Value; }
    public Difficulty Current { get; private set; } = Difficulty.Normal;

    public enum Difficulty
    {
        Easy = 0,
        Normal = 1,
        Hard = 2,
        VeryHard = 3
    }

    private GameDifficulty() { }

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
