using System.Xml;

namespace Mandatory2DGameFramework.Config;

public abstract class ConfigReaderWorker<T>
{
    public bool HasRead { get; protected set; } = false; // This is to support multi-threading if needed.
    public abstract T DefaultValue { get; protected set; }
    protected abstract T? Value { get; set; }

    public abstract void StartReadConfigFile(XmlDocument configFile);

    public T GetValue()
    {
        if (!HasRead)
        {
            throw new Exception("Make sure to set the HasRead property to true if the file was read.");
        }
        if (Value == null) { return DefaultValue; }
        return Value;
    }
}
