using VisDummy.Abstractions.Warp.NgReason;

namespace VisDummy.Abstractions.Warp
{
    public class SpotStationOkWarp_侧面贴胶检测
    {
        public string ImagePath_Camear { get; set; } = string.Empty;

        public ushort CamearNG { get; set; }

        public float Camear_Precision { get; set; }

        public string ToMsg()
        {
            return $"ImagePath_Camear:{ImagePath_Camear};CamearNG:{CamearNG};Camear_Precision:{Camear_Precision}";
        }
    }

    public class SpotStationErrWarp_侧面贴胶检测
    {
        public StationNgReason_SpotSide NgReason { get; set; }
        public string ImagePath_Camear { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"ImagePath_Camear:{ImagePath_Camear};NgReason:{NgReason}";
        }
    }
}
