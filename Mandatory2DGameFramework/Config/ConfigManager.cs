using System.Xml;

namespace Mandatory2DGameFramework.Config;

public sealed class ConfigManager
{
    private static ConfigManager Instance;

    public int[] WorldSize { get; private set; }

    private ConfigManager() { }

    public static ConfigManager GetInstance()
    {
        Instance ??= new ConfigManager();
        return Instance;
    }

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
