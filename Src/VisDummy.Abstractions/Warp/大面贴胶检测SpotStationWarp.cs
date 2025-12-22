using VisDummy.Abstractions.Warp.NgReason;

namespace VisDummy.Abstractions.Warp
{
    public class SpotStationOkWarp_大面贴胶检测
    {
        public string ImagePath { get; set; } = string.Empty;
        public float FeatureSize { get; set; }
        public float CameraPrecision { get; set; }
        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};FeatureSize:{FeatureSize};CameraPrecision:{CameraPrecision}";
        }
    }

    public class SpotStationErrWarp_大面贴胶检测
    {
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};ErrMsg:{ErrMsg};";
        }
    }
}
