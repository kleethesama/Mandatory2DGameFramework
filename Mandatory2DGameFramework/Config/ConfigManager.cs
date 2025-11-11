using System.Xml;

namespace Mandatory2DGameFramework.Config;

public sealed class ConfigManager
{
    private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());
    private readonly Lazy<ConfigReader<int[]>> _worldSizeReader = new(() => new WorldSizeConfigReader());
    private readonly Lazy<ConfigReader<int>> _difficultyReader = new(() => new DifficultyConfigReader());

    public static ConfigManager Instance { get => _instance.Value; }
    public ConfigReader<int[]> WorldSizeReader { get => _worldSizeReader.Value; }
    public ConfigReader<int> DifficultyReader { get => _difficultyReader.Value; }

    private ConfigManager() { }

    public static XmlDocument? LoadConfigFile(string filePath)
    {
        var config = new XmlDocument();
        try
        {
            config.Load(filePath);
        }
        catch (DirectoryNotFoundException) // Uses default values if file doesn't exist.
        {
            return null;
        }
        return config;
    }

    public void ConfigureAll(XmlDocument xmlDoc)
    {
        WorldSizeReader.StartReadConfigFile(xmlDoc);
        DifficultyReader.StartReadConfigFile(xmlDoc);
    }
}
