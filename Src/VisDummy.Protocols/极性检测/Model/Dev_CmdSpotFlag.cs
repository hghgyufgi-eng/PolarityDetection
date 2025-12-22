namespace VisDummy.Protocols.极性检测.Model
{
    [Flags]
    public enum Dev_CmdSpotFlag : ushort
    {
        None = 0,
        CameraTrigger = 1 << 0,
    }
}
