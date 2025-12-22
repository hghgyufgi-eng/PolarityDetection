using FutureTech.Protocols;
using System.Runtime.InteropServices;
using VisDummy.Abstractions.Warp.NgReason;
using VisDummy.Protocols.Common.Model;

namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Mst_CmdSpot
    {
        public Mst_CmdReplyFlag flag;

        [Endian(Endianness.BigEndian)]
        public float featureSize;

        [Endian(Endianness.BigEndian)]
        public float cameraPrecision;

        public bool Ack => flag.HasFlag(Mst_CmdReplyFlag.Ack);
        public bool AckOk => flag.HasFlag(Mst_CmdReplyFlag.Ack_Ok);
        public bool AckNg => flag.HasFlag(Mst_CmdReplyFlag.Ack_Ng);

        public float FeatureSize => featureSize;
        public float CameraPrecision => cameraPrecision;

        public void SetResult(float featureSize, float cameraPrecision)
        {
            this.featureSize = featureSize;
            this.cameraPrecision = cameraPrecision;
        }

        public void SetOn(bool isok)
        {
            flag = new MstMsg_CmdReplyFlagsBuilder(flag).SetOn(isok).Build();
        }

        public void SetOff()
        {
            flag = new MstMsg_CmdReplyFlagsBuilder(flag).SetOff().Build();
            featureSize = 0;
            cameraPrecision = 0;
        }
    }
}
