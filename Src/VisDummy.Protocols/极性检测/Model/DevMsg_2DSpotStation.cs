using System.Runtime.InteropServices;

namespace VisDummy.Protocols.极性检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class DevMsg_2DSpotStation
    {
        public Dev_CmdSpot CmdSpot;
    }
}
