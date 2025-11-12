using System.Xml;

namespace Mandatory2DGameFramework.Config;

public interface IConfigurable
{
    public bool TryConfigure(XmlDocument xmlDoc);
}
