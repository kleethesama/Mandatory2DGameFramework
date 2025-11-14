using System.Xml;

namespace Mandatory2DGameFramework.Config;

public interface IConfigurator
{
    public bool TryConfigure(XmlDocument xmlDoc);
}
