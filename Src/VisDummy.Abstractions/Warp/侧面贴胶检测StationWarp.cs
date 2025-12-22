using VisDummy.Abstractions.Warp.NgReason;

namespace VisDummy.Abstractions.Warp
{
    public class StationOkWrap_侧面贴胶检测
    {

        public ushort Cell1NG { get; set; }
        public ushort Cell2NG { get; set; }
        public ushort Cell3NG { get; set; }
        public ushort Cell4NG { get; set; }

        public string ImagePath_Cell1 { get; set; } = string.Empty;
        public string ImagePath_Cell2 { get; set; } = string.Empty;
        public string ImagePath_Cell3 { get; set; } = string.Empty;
        public string ImagePath_Cell4 { get; set; } = string.Empty;

        public CellLocation_侧面贴胶检测 CellLocation_Cell1 { get; set; } = new CellLocation_侧面贴胶检测();
        public CellLocation_侧面贴胶检测 CellLocation_Cell2 { get; set; } = new CellLocation_侧面贴胶检测();
        public CellLocation_侧面贴胶检测 CellLocation_Cell3 { get; set; } = new CellLocation_侧面贴胶检测();
        public CellLocation_侧面贴胶检测 CellLocation_Cell4 { get; set; } = new CellLocation_侧面贴胶检测();

        public string ToMsg()
        {
            return $"ImagePath_Cell1:{ImagePath_Cell1};ImagePath_Cell2:{ImagePath_Cell2};ImagePath_Cell3:{ImagePath_Cell3};ImagePath_Cell4:{ImagePath_Cell4};" +
                   $"Cell1NG:{Cell1NG};Cell2NG:{Cell2NG};Cell3NG:{Cell3NG};Cell4NG:{Cell4NG};" +
                   $"Cell1_Left:{CellLocation_Cell1.CellLocation_Left};Cell1_Right:{CellLocation_Cell1.CellLocation_Right};Cell1_Up:{CellLocation_Cell1.CellLocation_Up};" +
                   $"Cell2_Left:{CellLocation_Cell2.CellLocation_Left};Cell2_Right:{CellLocation_Cell2.CellLocation_Right};Cell2_Up:{CellLocation_Cell2.CellLocation_Up};" +
                   $"Cell3_Left:{CellLocation_Cell3.CellLocation_Left};Cell3_Right:{CellLocation_Cell3.CellLocation_Right};Cell3_Up:{CellLocation_Cell3.CellLocation_Up};" +
                   $"Cell4_Left:{CellLocation_Cell4.CellLocation_Left};Cell4_Right:{CellLocation_Cell4.CellLocation_Right};Cell4_Up:{CellLocation_Cell4.CellLocation_Up};";
        }
    }

    public class StationErrWrap_侧面贴胶检测
    {
        public StationNgReason_Side NgReason { get; set; }
        public string ImagePath_Cell1 { get; set; } = string.Empty;
        public string ImagePath_Cell2 { get; set; } = string.Empty;
        public string ImagePath_Cell3 { get; set; } = string.Empty;
        public string ImagePath_Cell4 { get; set; } = string.Empty;
        public string ErrMsg { get; set; } = string.Empty;
        public string ToMsg()
        {
            return $"NgReason:{NgReason};ImagePath_Cell1:{ImagePath_Cell1};ImagePath_Cell2:{ImagePath_Cell2};ImagePath_Cell3:{ImagePath_Cell3};ImagePath_Cell4:{ImagePath_Cell4};";
        }
    }

    public class CellLocation_侧面贴胶检测()
    {
        public float CellLocation_Left { get; set; }
        public float CellLocation_Right { get; set; }
        public float CellLocation_Up { get; set; }
        public string ToMsg()
        {
            return $"Left:{CellLocation_Left};Right:{CellLocation_Right};Up:{CellLocation_Up};";
        }
    }
}
