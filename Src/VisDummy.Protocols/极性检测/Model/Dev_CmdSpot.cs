using FutureTech.Protocols;
using System;
using System.Runtime.InteropServices;

namespace VisDummy.Protocols.极性检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Dev_CmdSpot
    {
        public Dev_CmdSpotFlag flag;

        [Endian(Endianness.BigEndian)]
        public ushort cameraNo;

        public bool CameraTrigger => flag.HasFlag(Dev_CmdSpotFlag.CameraTrigger);
        public ushort CameraNo => cameraNo;
    }
}
