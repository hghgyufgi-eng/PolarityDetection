using VisDummy.Abstractions.Warp.NgReason;

namespace VisDummy.Abstractions.Warp
{
    public class SpotStationOkWrap_Calibration
    {
        public string ImagePath { get; set; } = string.Empty;
        public float CameraPrecision { get; set; }
        public string ToMsg()
        {
            return $"cameraPrecision:{CameraPrecision};ImagePath:{ImagePath}";
        }
    }

    public class SpotStationErrWrap_Calibration
    {
        public StationNgReason_Calibration NgReason { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};NgReason:{NgReason};";
        }
    }

    public class SpotStationOkWrap_AutoCalibration
    {
        public string ImagePath { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};";
        }
    }

    public class SpotStationErrWrap_AutoCalibration
    {
        public StationNgReason_AutoCalibration NgReason { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};NgReason:{NgReason};";
        }
    }
}
