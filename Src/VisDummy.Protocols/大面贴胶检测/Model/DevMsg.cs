using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.Common.Model;
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class DevMsg
    {
        public Dev_CmdHeart Heart;

        /// <summary>
        /// 大面贴胶检测流程内轨道
        /// </summary>
        public DevMsg_2DStation Station2D1;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 40)]
        public byte[] __reserved1;

        /// <summary>
        /// 大面贴胶检测流程外轨道
        /// </summary>
        public DevMsg_2DStation Station2D2;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 40)]
        public byte[] __reserved2;

        /// <summary>
        /// NG替换
        /// </summary>
        public DevMsg_2DStation Station2D3_NGReplace;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 40)]
        public byte[] __reserved3;

        /// <summary>
        /// 前工位校验流程
        /// </summary>
        public DevMsg_2DSpotStation Station2DSpot;

    }
}
