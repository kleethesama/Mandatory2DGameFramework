using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Worlds;
using System.Xml;

namespace Mandatory2DGameFramework.GameManagement;

public class GameDifficulty : IConfigurable
{
    private static readonly Lazy<GameDifficulty> _instance = new(() => new GameDifficulty());

    public static GameDifficulty Instance { get => _instance.Value; }
    public Configurator<GameDifficulty>? Configurator { get; set; } = new DifficultyConfigurator();
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

    public bool TryConfigure(XmlDocument xmlDoc)
    {
        if (Configurator  == null) { return false; }
        return Configurator.TryConfigure(xmlDoc, this);
    }
}
