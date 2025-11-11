using System.Xml;

namespace Mandatory2DGameFramework.Config;

public sealed class ConfigManager
{
    private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());

    public static ConfigManager Instance { get => _instance.Value; }

    public int[] WorldSize { get; private set; }

    private ConfigManager() { }

    public void StartConfiguring(string filePath)
    {
        var config = new XmlDocument();
        try
        {
            config.Load(filePath); 
        }
        catch (DirectoryNotFoundException) // Uses default values later if loading fails.
        {
            throw;
        }
        SetWorldSize(config);
    }

    private void SetWorldSize(XmlDocument xmlDoc)
    {
        var reader = new WorldSizeConfigReader();
        reader.StartReadConfigFile(xmlDoc);
        WorldSize = reader.GetValue();
    }
}
