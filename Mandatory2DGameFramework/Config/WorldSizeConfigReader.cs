using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class WorldSizeConfigReader : ConfigReader<int[]>
{
    public override int[] DefaultValue { get; } = [20, 20];
    protected override int[]? Value { get; set; }

    public override void StartReadConfigFile(XmlDocument xmlDoc)
    {
        try
        {
            base.StartReadConfigFile(xmlDoc);
            XmlNode? worldSizeNode = _parentNode?.SelectSingleNode("WorldSize");
            Value = ConvertToValue(worldSizeNode);
        }
        catch (Exception)
        {
            Value = DefaultValue;
        }
    }

    protected override int[] ConvertToValue(XmlNode? parentNode)
    {
        if (parentNode == null) { return DefaultValue; }
        var nodeX = parentNode.SelectSingleNode("X");
        var nodeY = parentNode.SelectSingleNode("Y");
        if (nodeX == null || nodeY == null) { return DefaultValue; }
        return [Convert.ToInt32(nodeX.InnerText), Convert.ToInt32(nodeY.InnerText)];
    }
}
