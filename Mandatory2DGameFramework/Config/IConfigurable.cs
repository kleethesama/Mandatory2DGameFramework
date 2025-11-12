using System.Xml;

namespace Mandatory2DGameFramework.Config;

public interface IConfigurable
{
    public bool Configure(XmlDocument xmlDoc);
}
