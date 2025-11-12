using System.Xml;

namespace Mandatory2DGameFramework.Config;

public sealed class ConfigManager
{
    private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());
    private readonly XmlDocument _xmlDocument = new();
    private bool _isXmlLoaded = false;

    public static ConfigManager Instance { get => _instance.Value; }
    public static string ConfigFilePath { get; set; } =
        "C:\\Users\\fck\\source\\repos\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Config\\WorldTestFile.xml";

    private ConfigManager() { }

    public void LoadConfigFile()
    {
        if (_isXmlLoaded) { return; }
        try
        {
            _xmlDocument.Load(ConfigFilePath);
            _isXmlLoaded = true;
        }
        catch (FileNotFoundException) // Uses default values if file doesn't exist.
        {
            // Log what happened.
            throw; // Rethrow so caller is aware this happened.
        }
    }

    public void ConfigureAll(IList<IConfigurable> configurables)
    {
        if (!_isXmlLoaded)
        {
            throw new Exception($"Xml file is not loaded: {nameof(_isXmlLoaded)} = {_isXmlLoaded}");
        }
        foreach (var configer in configurables)
        {
            if (!configer.Configure(_xmlDocument))
            {
                // Log that object failed to be modified.
            }
        }
    }
}
