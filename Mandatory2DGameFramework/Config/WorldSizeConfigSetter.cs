namespace Mandatory2DGameFramework.Config;

public class WorldSizeConfigSetter(ConfigReaderWorker<int[]> reader) : ConfigSetterWorker<int[]>(reader)
{
    public override void Set(ref int[] reference, int[] value)
    {
        reference = value;
    }
}
