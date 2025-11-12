using System.Xml;

namespace Mandatory2DGameFramework.Config;

public abstract class Configurator<T> where T : class
{
    protected XmlNode? _parentNode;

    protected virtual void StartReadConfigFile(XmlDocument xmlDoc)
    {
        _parentNode = xmlDoc.SelectSingleNode("GameConfig");
        if (_parentNode == null)
        {
            throw new Exception("Couldn't find GameConfig node.");
        }
    }

    public abstract bool TryConfigure(XmlDocument xmlDoc, T configuredObject);
}
