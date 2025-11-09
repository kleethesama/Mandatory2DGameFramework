using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class WorldSizeConfigReader : ConfigReaderWorker<int[]>
{
    protected override int[] Value { get; set; } = [20, 20];

    public override void StartReadConfigFile(XmlDocument xmlDoc)
    {
        XmlNode? worldSizeNode = xmlDoc.SelectSingleNode("WorldSize");
        if (worldSizeNode != null)
        {
            var array = new int[Value.Length];
            for (int i = 0; i < worldSizeNode.ChildNodes.Count; i++)
            {
                string? value = worldSizeNode.ChildNodes[i].Value;
                if (value == null)
                {
                    HasRead = true;
                    return;
                }
                array[i] = Convert.ToInt32(value);
            }
            Value = array;
        }
        HasRead = true;
    }
}
