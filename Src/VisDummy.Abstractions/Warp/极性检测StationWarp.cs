using System;
using VisDummy.Abstractions.Warp.NgReason;

namespace VisDummy.Abstractions.Warp
{
    public class StationOkWrap_极性检测
    {
        public CellDetail CellDetai1 { get; set; }
        public CellDetail CellDetai2 { get; set; }
        public CellDetail CellDetai3 { get; set; }
        public CellDetail CellDetai4 { get; set; }
        public int ParameterStatus { get; set; }
        public string ToMsg()
        {
            return $"CellLocation1:{CellDetai1.ToMsg()};CellLocation2:{CellDetai2.ToMsg()};ParameterStatus:{ParameterStatus}";
        }
    }

    public class StationErrWrap_极性检测
    {
        public string ErrMsg { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int ParameterStatus { get; set; }
        public string ToMsg()
        {
            return $"ErrMsg:{ErrMsg};ImagePath:{ImagePath};ParameterStatus:{ParameterStatus}";
        }
    }

    public class CellDetail
    {
        public int CellWhether { get; set; }

        public string CellCode { get; set; }

        public int CellPolarity { get; set; }

        public int CellVariety { get; set; }

        public string ToMsg()
        {
            return $"CellWhether:{CellWhether};CellCode:{CellCode};CellPolarity:{CellPolarity};CellVariety:{CellVariety};";
        }
    }

}
