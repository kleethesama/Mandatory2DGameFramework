using System.Xml;

namespace Mandatory2DGameFramework.Config;

public abstract class ConfigReaderWorker<T>
{
    public bool HasRead { get; protected set; } = false; // This is to support multi-threading if needed.
    protected abstract T Value { get; set; }

    public abstract void StartReadConfigFile(XmlDocument configFile);

    public T GetValue()
    {
        if (!HasRead)
        {
            throw new Exception("Make sure to set the HasRead property to true if the file was read.");
        }
        return Value;
    }
}
