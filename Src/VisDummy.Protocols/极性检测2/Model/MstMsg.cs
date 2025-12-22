using System.Runtime.InteropServices;
using VisDummy.Protocols.Common.Model;
using VisDummy.Protocols.极性检测.Model;

namespace VisDummy.Protocols.极性检测2.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class MstMsg
    {
        //public Mst_CmdHeart Heart;

        ///// <summary>
        ///// 检测流程1
        ///// </summary>
        //public MstMsg_2DStation Station2D;


        /// <summary>
        /// 检测流程2
        public MstMsg_2DStation Station2D1;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32)]
        public byte[] __reserved2;
        public MstMsg_2DSpotStation SpotStation;


    }
}
