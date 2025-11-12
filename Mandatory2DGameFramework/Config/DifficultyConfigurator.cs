using Mandatory2DGameFramework.GameManagement;
using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class DifficultyConfigurator : Configurator<GameDifficulty>
{
    public override bool TryConfigure(XmlDocument xmlDoc, GameDifficulty configuredObject)
    {
        base.StartReadConfigFile(xmlDoc);
        XmlNode? diffNode = _parentNode?.SelectSingleNode("Difficulty");
        if (diffNode == null) { return false; }
        if (Enum.TryParse(diffNode.InnerText, true, out GameDifficulty.Difficulty value))
        {
            configuredObject.SetDifficulty(value);
            return true;
        }
        return false;
    }
}
