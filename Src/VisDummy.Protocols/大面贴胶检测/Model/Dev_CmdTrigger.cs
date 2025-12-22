using FutureTech.Protocols;
using System.Runtime.InteropServices;

namespace VisDummy.Protocols.大面贴胶检测.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Dev_CmdTrigger
    {
        public Dev_CmdTriggerFlag flag;

        /// <summary>
        /// 功能号
        /// </summary>
        [Endian(Endianness.BigEndian)]
        public ushort function;

        /// <summary>
        /// 拍照位置
        /// </summary>
        [Endian(Endianness.BigEndian)]
        public ushort photoPosition;

        /// <summary>
        /// 批次号
        /// </summary>
        [Endian(Endianness.BigEndian)]
        public uint batch;

        public bool Trigger => flag.HasFlag(Dev_CmdTriggerFlag.Trigger1);

        public ushort Function => function;
        public ushort PhotoPosition => photoPosition;
        public uint Batch => batch;
    }
}
