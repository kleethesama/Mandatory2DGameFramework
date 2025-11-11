using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class WorldSizeConfigReader : ConfigReaderWorker<int[]>
{
    protected override int[] Value { get; set; } = [20, 20];

    public override void StartReadConfigFile(XmlDocument xmlDoc)
    {
        XmlNode? GameConfigNode = xmlDoc.SelectSingleNode("GameConfig");
        if (GameConfigNode == null)
        {
            HasRead = true;
            return;
        }
        XmlNode? worldSizeNode = GameConfigNode.SelectSingleNode("WorldSize");
        if (worldSizeNode != null)
        {
            if (TryConvertToValue(worldSizeNode, "X", out int valueX)
                && TryConvertToValue(worldSizeNode, "Y", out int valueY))
            {
                Value[0] = valueX;
                Value[1] = valueY;
            }
        }
        HasRead = true;
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
