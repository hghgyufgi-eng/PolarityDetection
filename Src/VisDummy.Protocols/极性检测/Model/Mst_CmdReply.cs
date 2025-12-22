using FutureTech.Protocols;
using System.Runtime.InteropServices;
using VisDummy.Abstractions.Warp.NgReason;
using VisDummy.Protocols.Common;
using VisDummy.Protocols.Common.Model;

namespace VisDummy.Protocols.极性检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Mst_CmdReply
    {
        public Mst_CmdReplyFlag flag;

        public CellDetail cellDetail1;

        public CellDetail cellDetail2;

        [Endian(Endianness.BigEndian)]
        public ushort parameterStatus;
        /// <summary>
        /// 预留8个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
        public byte[] __reserved2;


        public bool Ack => flag.HasFlag(Mst_CmdReplyFlag.Ack);
        public bool AckOk => flag.HasFlag(Mst_CmdReplyFlag.Ack_Ok);
        public bool AckNg => flag.HasFlag(Mst_CmdReplyFlag.Ack_Ng);
        public CellDetail CellDetail1 => cellDetail1;
        public CellDetail CellDetail2 => cellDetail2;
        public ushort ParameterStatus => parameterStatus;

        public void SetOnResult(CellDetail c1, CellDetail c2,int pstatus)
        {
            cellDetail1.SetResult(c1);
            cellDetail2.SetResult(c2);
            parameterStatus = (ushort)pstatus;
        }

        public void SetOn(bool isok)
        {
            flag = new MstMsg_CmdReplyFlagsBuilder(flag).SetOn(isok).Build();
        }
        public void SetOff()
        {
            flag = new MstMsg_CmdReplyFlagsBuilder(flag).SetOff().Build();
            cellDetail1.SetReset();
            cellDetail2.SetReset();
            parameterStatus = 0;
        }

    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class CellDetail
    {
        [Endian(Endianness.BigEndian)]
        public ushort cellWhether;

        [Endian(Endianness.BigEndian)]
        public String30 cellCode;

        [Endian(Endianness.BigEndian)]
        public ushort cellPolarity;

        [Endian(Endianness.BigEndian)]
        public ushort cellVariety;

        public ushort CellWhether => cellWhether;
        public String30 CellCode => cellCode;
        public ushort CellPolarity => cellPolarity;
        public ushort CellVariety => cellVariety;

        public void SetReset()
        {
            cellWhether = 0;
            cellCode = default;
            cellPolarity = 0;
            cellVariety = 0;
        }

        public void SetResult(CellDetail cellDetail)
        {
            cellWhether = cellDetail.CellWhether;
            cellCode = cellDetail.CellCode;
            cellPolarity = cellDetail.CellPolarity;
            cellVariety = cellDetail.CellVariety;
        }

    }
}
