namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [Flags]
    public enum Dev_CmdTriggerFlag : ushort
    {
        None = 0,
        Trigger1 = 1 << 0,
    }
}
