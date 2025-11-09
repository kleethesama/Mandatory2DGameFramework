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
        config.LoadXml(filePath);
        SetWorldSize(config);
    }

    private void SetWorldSize(XmlDocument xmlDoc)
    {
        var reader = new WorldSizeConfigReader();
        reader.StartReadConfigFile(xmlDoc);
        if (reader.HasRead) // This is to support multi-threading if needed.
        {
            WorldSize = reader.GetValue();
        }
    }
}
