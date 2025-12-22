using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.Common.Model;
using VisDummy.Protocols.极性检测.Model;

namespace VisDummy.Protocols.极性检测2.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class DevMsg
    {
        //public Dev_CmdHeart Heart;

        ///// <summary>
        ///// 检测流程1
        ///// </summary>
        //public DevMsg_2DStation Station2D;

        /// <summary>
        /// 检测流程2
        /// </summary>
        public DevMsg_2DStation Station2D1;

        /// <summary>
        /// 预留40个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32)]
        public byte[] __reserved2;


        /// <summary>
        /// 前工位校验流程
        /// </summary>
        public DevMsg_2DSpotStation Station2DSpot;

    }
}
