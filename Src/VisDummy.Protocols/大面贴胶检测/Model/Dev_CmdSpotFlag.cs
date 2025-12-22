namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [Flags]
    public enum Dev_CmdSpotFlag : ushort
    {
        None = 0,
        CameraTrigger = 1 << 0,
    }
}
