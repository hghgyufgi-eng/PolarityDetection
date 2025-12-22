namespace VisDummy.Protocols.极性检测.Model
{
    [Flags]
    public enum Dev_CmdTriggerFlag : ushort
    {
        None = 0,
        Trigger1 = 1 << 0,
    }
}
