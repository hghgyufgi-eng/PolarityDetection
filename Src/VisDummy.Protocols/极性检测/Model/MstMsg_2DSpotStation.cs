using System.Runtime.InteropServices;

namespace VisDummy.Protocols.极性检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class MstMsg_2DSpotStation
    {
        public Mst_CmdSpot CmdSpot;
    }
}
