using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisDummy.Abstractions.Args
{
    public class StationArgs_Polarity
    {
        /// <summary>
        /// 功能号
        /// </summary>
        public ushort Function { get; set; }

        /// <summary>
        /// 拍照位置
        /// </summary>
        public ushort PhotoPosition { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public uint Batch { get; set; }


        /// <summary>
        /// 拍照次数
        /// </summary>
        public ushort Phototimes { get; set; }


        public string ToMsg()
        {
            return $"Function:{Function};PhotoPosition:{PhotoPosition};Batch:{Batch},Phototimes:{Phototimes}";
        }
    }
}
