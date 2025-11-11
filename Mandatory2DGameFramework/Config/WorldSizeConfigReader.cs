using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class WorldSizeConfigReader : ConfigReader<int[]>
{
    public override int[] DefaultValue { get; protected set; } = [20, 20];
    protected override int[]? Value { get; set; }

    public override void StartReadConfigFile(XmlDocument xmlDoc)
    {
        base.StartReadConfigFile(xmlDoc);
        if (_parentNode == null) { return; }
        XmlNode? worldSizeNode = _parentNode.SelectSingleNode("WorldSize");
        if (worldSizeNode != null)
        {
            if (TryConvertToValue(worldSizeNode, "X", out int valueX)
                && TryConvertToValue(worldSizeNode, "Y", out int valueY))
            {
                Value = [valueX, valueY];
            }
        }
    }

    private static bool TryConvertToValue(XmlNode? parentNode, string xpath, out int value)
    {
        if (parentNode == null)
        {
            value = default;
            return false;
        }
        var mainNode = parentNode.SelectSingleNode(xpath);
        if (mainNode == null)
        {
            value = default;
            return false;
        }
        value = Convert.ToInt32(mainNode.InnerText);
        return true;
    }
}
