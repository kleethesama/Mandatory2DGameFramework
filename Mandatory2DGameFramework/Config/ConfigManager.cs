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

    public void StartConfiguring()
    {
        var worldSizeReader = new WorldSizeConfigReader();
        var worldSizeSetter
    }
}
