using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class ConfigManager
{
    private static ConfigManager Instance;

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
    }

    //private void ReadWorldSize(XmlDocument xmlDoc)
    //{
    //    var worldSizeReader = new WorldSizeConfigReader();
    //    worldSizeReader.StartReadConfigFile(xmlDoc);
    //    if (worldSizeReader.HasRead)
    //    {

    //    }
    //}
}
