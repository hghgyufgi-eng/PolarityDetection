namespace VisDummy.Abstractions.Warp.NgReason
{
    [Flags]
    public enum StationNgReason_Large : byte
    {
        None = 0,
        无左电芯 = 1 << 0,
        无右电芯 = 1 << 1,
        无左胶料 = 1 << 2,
        无右胶料 = 1 << 3,
        左未撕纸 = 1 << 4,
        右未撕纸 = 1 << 5,
        输入参数状态 = 1 << 6,
    }

    [Flags]
    public enum StationNgReason_SpotLarge : byte
    {
        None = 0,
        找特征点NG = 1 << 1,
        视觉流程NG = 1 << 2
    }

    [Flags]
    public enum StationNgReason_Side : byte
    {
        None = 0,
        PLC参数NG = 1 << 0,
        找特征点NG = 1 << 1,
        视觉流程NG = 1 << 2
    }

    [Flags]
    public enum StationNgReason_SpotSide : byte
    {
        None = 0,
        找特征点NG = 1 << 1,
        视觉流程NG = 1 << 2
    }

    [Flags]
    public enum StationNgReason_ModuleLead : byte
    {
        None = 0,
        特征点NG = 1 << 0,
        视觉检测流程NG = 1 << 1,
        其他NG = 1 << 2,
        PLC参数NG = 1 << 3,
        偏移量NG = 1 << 4,
        模组长度NG = 1 << 5
    }

    [Flags]
    public enum StationNgReason_ScanCode : byte
    {
        None = 0,
        PLC参数NG = 1 << 0,
        找特征点NG = 1 << 1,
        极性NG = 1 << 2,
        视觉流程NG = 1 << 3
    }

    [Flags]
    public enum StationNgReason_InBoxLead : byte
    {
        None = 0,
        特征点NG = 1 << 0,
        视觉检测流程NG = 1 << 1,
        其他NG = 1 << 2,
        PLC参数NG = 1 << 3,
        偏移量NG = 1 << 4,
        间距NG = 1 << 5
    }

    [Flags]
    public enum StationNgReason_Down : byte
    {
        None = 0,
        视觉检测流程NG = 1 << 0,
        底部异物NG = 1 << 1
    }

    [Flags]
    public enum StationNgReason_Calibration : byte
    {
        None = 0,
        找特征点NG = 1 << 0,
        视觉检测流程NG = 1 << 1,
        PLC参数NG = 1 << 2,
        偏移量NG = 1 << 3
    }

    [Flags]
    public enum StationNgReason_AutoCalibration : byte
    {
        None = 0,
        特征点NG = 1 << 0,
        视觉检测流程NG = 1 << 1,
        其他NG = 1 << 2,
        PLC参数NG = 1 << 3
    }
}
