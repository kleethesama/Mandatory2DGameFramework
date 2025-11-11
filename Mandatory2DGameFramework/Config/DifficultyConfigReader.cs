using System.Xml;

namespace Mandatory2DGameFramework.Config;

public class DifficultyConfigReader : ConfigReader<int>
{
    public override int DefaultValue { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }
    protected override int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void StartReadConfigFile(XmlDocument configFile)
    {
        throw new NotImplementedException();
    }
}
