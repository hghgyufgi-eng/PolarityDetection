using FutureTech.Protocols;
using System.Runtime.InteropServices;

namespace VisDummy.Protocols.极性检测.Model
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
        /// 拍照位置号
        /// </summary>
        [Endian(Endianness.BigEndian)]
        public ushort photoPosition;
        
        /// <summary>
        /// 批次号
        /// </summary>
        [Endian(Endianness.BigEndian)]
        public uint batch;

        /// <summary>
        /// 批次号
        /// </summary>
        [Endian(Endianness.BigEndian)]
        public ushort phototimes;


        /// <summary>
        /// 预留8个字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
        public byte[] __reserved2;
        public bool Trigger => flag.HasFlag(Dev_CmdTriggerFlag.Trigger1);

        public ushort Function => function;

        public ushort PhotoPosition => photoPosition;

        public uint Batch => batch;
        public ushort Phototimes => phototimes;
    }
}
