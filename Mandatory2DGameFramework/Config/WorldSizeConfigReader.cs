namespace Mandatory2DGameFramework.Config;

public class WorldSizeConfigReader : ConfigReaderWorker<int[]>
{
    public override int[] DefaultValue { get; protected set; } = [20, 20];

    public override void StartReadConfigFile()
    {
        throw new NotImplementedException();
    }

    public override int[] GetValue()
    {
        throw new NotImplementedException();
    }
}
