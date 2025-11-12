using Mandatory2DGameFramework.Worlds;
using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class WorldSizeConfigurator : Configurator<World>
{
    public override bool TryConfigure(XmlDocument xmlDoc, World configuredObject)
    {
        base.StartReadConfigFile(xmlDoc);
        XmlNode? worldSizeNode = _parentNode?.SelectSingleNode("WorldSize");
        var nodeX = worldSizeNode?.SelectSingleNode("X");
        var nodeY = worldSizeNode?.SelectSingleNode("Y");
        if (nodeX == null || nodeY == null) { return false; }
        int xValue;
        int yValue;
        try
        {
            xValue = Convert.ToInt32(nodeX.InnerText);
            yValue = Convert.ToInt32(nodeY.InnerText);
        }
        catch
        {
            return false;
        }
        configuredObject.MaxX = xValue;
        configuredObject.MaxY = yValue;
        return true;
    }
}
