using System.Xml;

namespace Mandatory2DGameFramework.Config;

public sealed class ConfigManager
{
    private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());
    private int[] _worldSize;

    public static ConfigManager Instance { get => _instance.Value; }

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
            _worldSize = StartWorldSizeReader(config).DefaultValue;
            return;
        }
        _worldSize = StartWorldSizeReader(config).GetValue();
    }

    public int[] GetWorldSize() => [.. _worldSize];

    private static ConfigReaderWorker<int[]> StartWorldSizeReader(XmlDocument xmlDoc)
    {
        var reader = new WorldSizeConfigReader();
        reader.StartReadConfigFile(xmlDoc);
        return reader;
    }
}
