using Mandatory2DGameFramework.GameManagement;
using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class DifficultyConfigReader : ConfigReader<int>
{
    public override int DefaultValue { get; } = (int)GameDifficulty.Difficulty.Normal;
    protected override int Value { get; set; }

    public override void StartReadConfigFile(XmlDocument xmlDoc)
    {
        base.StartReadConfigFile(xmlDoc);
        try
        {
            base.StartReadConfigFile(xmlDoc);
            XmlNode? diffNode = _parentNode?.SelectSingleNode("Difficulty");
            Value = ConvertToValue(diffNode);
        }
        catch (Exception)
        {
            Value = DefaultValue;
        }
    }

    protected override int ConvertToValue(XmlNode? parentNode)
    {
        if (parentNode == null) { return DefaultValue; }
        if (Enum.TryParse(parentNode.InnerText, true, out GameDifficulty.Difficulty value))
        {
            return (int)value;
        }
        return DefaultValue;
    }
}
