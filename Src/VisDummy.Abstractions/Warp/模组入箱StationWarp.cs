using VisDummy.Abstractions.Warp.NgReason;

namespace VisDummy.Abstractions.Warp
{
    public class StationOkWrap_Lead
    {
        public string ImagePath { get; set; } = string.Empty;
        public float X { get; set; }
        public float Y { get; set; }
        public float A { get; set; }
        public float ModuleLength { get; set; }

        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};X:{X};Y:{Y};A:{A};ModuleLength:{ModuleLength}";
        }
    }

    public class StationErrWrap_ModuleLead
    {
        public StationNgReason_ModuleLead NgReason { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"NgReason:{NgReason};ImagePath:{ImagePath};";
        }
    }

    public class StationErrWrap_InBoxLead
    {
        public StationNgReason_InBoxLead NgReason { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"NgReason:{NgReason};ImagePath:{ImagePath};";
        }
    }
    public class StationOkWrap_ScanCode
    {
        public string ImagePath { get; set; } = string.Empty;
        
        public string CellCode1 { get; set; } = string.Empty;
        public string? CellCode2 { get; set; } = string.Empty;


        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};CellCode1:{CellCode1};CellCode2:{CellCode2}";
        }
    }

    public class StationErrWrap_ScanCode
    {
        public StationNgReason_ScanCode NgReason { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"NgReason:{NgReason};ImagePath:{ImagePath};";
        }
    }

    public class StationOkWrap_Down
    {
        public string ImagePath { get; set; } = string.Empty;

        public string ToMsg()
        {
            return $"ImagePath:{ImagePath};";
        }
    }

    public class StationErrWrap_Down
    {
        public StationNgReason_Down NgReason { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"NgReason:{NgReason};ImagePath:{ImagePath};";
        }
    }
}
