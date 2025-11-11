using System.Xml;

namespace Mandatory2DGameFramework.Config;

public abstract class ConfigReader<T>
{
    protected XmlNode? _parentNode;

    public abstract T DefaultValue { get; protected set; }
    protected abstract T? Value { get; set; }

    public virtual void StartReadConfigFile(XmlDocument xmlDoc)
    {
        _parentNode = xmlDoc.SelectSingleNode("GameConfig");
    }

    public T GetValue()
    {
        if (Value == null) { return DefaultValue; }
        return Value;
    }
}
