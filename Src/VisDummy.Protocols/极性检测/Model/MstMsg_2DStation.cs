using System.Runtime.InteropServices;
using FutureTech.Protocols;
using VisDummy.Protocols.Common.Model;
using VisDummy.Abstractions.Args;
using VisDummy.Abstractions.Warp;

namespace VisDummy.Protocols.极性检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class MstMsg_2DStation
    {
        public Mst_CmdReply CmdReply;
    }

}
