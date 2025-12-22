using System.Runtime.InteropServices;
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class DevMsg_2DStation
    {
        public Dev_CmdTrigger CmdTrigger;
    }
}
