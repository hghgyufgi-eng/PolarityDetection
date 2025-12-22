using FutureTech.Protocols;
using System.Runtime.InteropServices;
using VisDummy.Abstractions.Warp.NgReason;
using VisDummy.Protocols.Common.Model;

namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Mst_CmdReply
    {
        public Mst_CmdReplyFlag flag;

        public StationNgReason_Large ngReason;

        public bool 无左电芯 => ngReason.HasFlag(StationNgReason_Large.无左电芯);
        public bool 无右电芯 => ngReason.HasFlag(StationNgReason_Large.无右电芯);
        public bool 无左胶料 => ngReason.HasFlag(StationNgReason_Large.无左胶料);
        public bool 无右胶料 => ngReason.HasFlag(StationNgReason_Large.无右胶料);
        public bool 左未撕纸 => ngReason.HasFlag(StationNgReason_Large.左未撕纸);
        public bool 右未撕纸 => ngReason.HasFlag(StationNgReason_Large.右未撕纸);
        public bool 输入参数状态 => ngReason.HasFlag(StationNgReason_Large.输入参数状态);

        public bool Ack => flag.HasFlag(Mst_CmdReplyFlag.Ack);
        public bool AckOk => flag.HasFlag(Mst_CmdReplyFlag.Ack_Ok);
        public bool AckNg => flag.HasFlag(Mst_CmdReplyFlag.Ack_Ng);

        public void SetOn(bool isok)
        {
            flag = new MstMsg_CmdReplyFlagsBuilder(flag).SetOn(isok).Build();
        }
        public void SetOff()
        {
            flag = new MstMsg_CmdReplyFlagsBuilder(flag).SetOff().Build();
        }
    }
}
