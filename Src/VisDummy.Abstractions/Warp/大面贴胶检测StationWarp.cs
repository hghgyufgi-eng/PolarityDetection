using VisDummy.Abstractions.Warp.NgReason;

namespace VisDummy.Abstractions.Warp
{
    public class StationOkWrap_大面贴胶检测
    {
        public string ImagePath { get; set; } = string.Empty;

        public string ToMsg()
        {
            return $"ImagePath:{ImagePath}";   
        }
    }

    public class StationErrWrap_大面贴胶检测
    {
        public StationNgReason_Large NgReason { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"NgReason:{NgReason};ImagePath:{ImagePath};";
        }
    }

    public class CellLocation()
    {
        public float cellLocation_Left { get; set; }
        public float cellLocation_Right { get; set; }
        public float cellLocation_Up { get; set; }
        public float cellLocation_Down { get; set; }
        public string ToMsg()
        {
            return $"Left:{cellLocation_Left};Right:{cellLocation_Right};Up:{cellLocation_Up};Down:{cellLocation_Down}";
        }
    }
}
