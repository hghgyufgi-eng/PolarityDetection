using System.Runtime.InteropServices;
using VisDummy.Protocols.Common.Model;

namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class MstMsg
    {
        public Mst_CmdHeart Heart;

        /// <summary>
        /// 大面贴胶检测内轨道
        /// </summary>
        public MstMsg_2DStation Station2D1;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 40)]
        public byte[] __reserved1;

        /// <summary>
        /// 大面贴胶检测外轨道
        /// </summary>
        public MstMsg_2DStation Station2D2;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 40)]
        public byte[] __reserved2;

        /// <summary>
        /// 大面贴胶检测NG替换
        /// </summary>
        public MstMsg_2DStation Station2D3_NGReplace;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 40)]
        public byte[] __reserved3;

        /// <summary>
        /// 视觉精度校验
        /// </summary>
        public MstMsg_2DSpotStation Station2DSpot;

    }
}
