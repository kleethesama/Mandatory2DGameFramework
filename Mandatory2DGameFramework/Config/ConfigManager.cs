using Mandatory2DGameFramework.Logging;
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
        try
        {
            _xmlDocument.Load(ConfigFilePath);
            _isXmlLoaded = true;
        }
        catch (FileNotFoundException) // Uses default values if file doesn't exist.
        {
            MyLogger.Instance.GetTraceSource(nameof(ConfigManager))?.TraceEvent(
                System.Diagnostics.TraceEventType.Error, 1,
                "Couldn't find the XML config file. Default values will be used instead.");
            throw; // Rethrow so caller is aware this happened.
        }
    }

    public void ConfigureAll(IList<Configurator> configurators)
    {
        if (!_isXmlLoaded)
        {
            throw new Exception($"Xml file is not loaded: {nameof(_isXmlLoaded)} = {_isXmlLoaded}");
        }
        foreach (var config in configurators)
        {
            MyLogger.Instance.GetTraceSource(nameof(ConfigManager)).TraceEvent(
                System.Diagnostics.TraceEventType.Information, 2,
                $"Configurating using configurator: {config.GetType()}");

            if (!config.TryConfigure(_xmlDocument))
            {
                MyLogger.Instance.GetTraceSource(nameof(ConfigManager)).TraceEvent(
                    System.Diagnostics.TraceEventType.Error, 2,
                    $"The following configurator failed: {config.GetType()}");
            }
        }
    }
}
