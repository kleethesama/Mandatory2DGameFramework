using System.Xml;

namespace Mandatory2DGameFramework.Config;

public abstract class Configurator
{
    protected XmlNode? _parentNode;

    public virtual bool ReadAndConfigure(XmlDocument xmlDoc)
    {
        _parentNode = xmlDoc.SelectSingleNode("GameConfig");
        if (_parentNode == null)
        {
            throw new Exception("Couldn't find GameConfig node.");
        }
        return TryConfigure(xmlDoc);
    }

    protected abstract bool TryConfigure(XmlDocument xmlDoc);
}
