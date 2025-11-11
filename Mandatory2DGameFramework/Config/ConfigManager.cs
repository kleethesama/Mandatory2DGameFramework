using Mandatory2DGameFramework.GameManagement;
using System.Xml;

namespace Mandatory2DGameFramework.Config;

public sealed class ConfigManager
{
    private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());

    public static ConfigManager Instance { get => _instance.Value; }
    public ConfigReaderWorker<int[]> WorldSizeReader { get; private set; } = new WorldSizeConfigReader();
    public ConfigReaderWorker<GameDifficulty.Difficulty> DifficultyReader { get; private set; }

    private ConfigManager() { }

    public void StartConfiguring(string filePath)
    {
        var config = new XmlDocument();
        try
        {
            config.Load(filePath);
        }
        catch (DirectoryNotFoundException) // Uses default values later if file doesn't exist.
        {
            return;
        }
        WorldSizeReader.StartReadConfigFile(config);
    }
}
