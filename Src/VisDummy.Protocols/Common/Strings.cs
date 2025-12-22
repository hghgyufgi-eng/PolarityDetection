using System;
using System.Runtime.InteropServices;

namespace VisDummy.Protocols.Common
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class BarCode
    {
        public byte TotalLength;
        public byte EffectiveLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string Content;

        public String EffectiveContent
        {
            get => this.Content?.Substring(0, Math.Min(this.EffectiveLength, this.Content.Length));
            set
            {
                var v = String.IsNullOrEmpty(value) ? String.Empty : value;
                this.Content = v;
                this.TotalLength = 30;
                this.EffectiveLength = (byte)v.Length;
            }
        }

        public static BarCode New(string content)
        {
            var len = content.Length;
            if (len > 30)
            {
                throw new ArgumentOutOfRangeException($"字符串{content}长度={len}，大于最大值({30})");
            }

            return new BarCode
            {
                TotalLength = 30,
                EffectiveLength = (byte)content.Length,
                Content = content,
            };
        }
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class String30
    {
        private const int MAX_SIZE = 30;

        public byte TotalLength;
        public byte EffectiveLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SIZE)]
        public string Content;

        public String EffectiveContent
        {
            get => this.Content?.Substring(0, Math.Min(this.EffectiveLength, this.Content.Length));
            set
            {
                var v = String.IsNullOrEmpty(value) ? String.Empty : value;
                this.Content = v;
                this.TotalLength = MAX_SIZE;
                this.EffectiveLength = (byte)v.Length;
            }
        }

        public static String30 New(string content)
        {
            var len = content.Length;
            if (len > MAX_SIZE)
            {
                throw new ArgumentOutOfRangeException($"字符串{content}长度={len}，大于最大值({MAX_SIZE})");
            }

            return new String30
            {
                TotalLength = MAX_SIZE,
                EffectiveLength = (byte)content.Length,
                Content = content,
            };
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class String40
    {
        private const int MAX_SIZE = 38;

        public byte TotalLength;
        public byte EffectiveLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SIZE)]
        public string Content;

        public String EffectiveContent
        {
            get => this.Content?.Substring(0, Math.Min(this.EffectiveLength, this.Content.Length));
            set
            {
                var v = String.IsNullOrEmpty(value) ? String.Empty : value;
                this.Content = v;
                this.TotalLength = MAX_SIZE;
                this.EffectiveLength = (byte)v.Length;
            }
        }

        public static String40 New(string content)
        {
            var len = content.Length;
            if (len > MAX_SIZE)
            {
                throw new ArgumentOutOfRangeException($"字符串{content}长度={len}，大于最大值({MAX_SIZE})");
            }

            return new String40
            {
                TotalLength = MAX_SIZE,
                EffectiveLength = (byte)content.Length,
                Content = content,
            };
        }
    }



    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class String62
    {
        private const int MAX_SIZE = 62;

        public byte TotalLength;
        public byte EffectiveLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SIZE)]
        public string Content;

        public String EffectiveContent
        {
            get => this.Content?.Substring(0, Math.Min(this.EffectiveLength, this.Content.Length));
            set
            {
                var v = String.IsNullOrEmpty(value) ? String.Empty : value;
                this.Content = v;
                this.TotalLength = MAX_SIZE;
                this.EffectiveLength = (byte)v.Length;
            }
        }

        public static String62 New(string content)
        {
            var len = content.Length;
            if (len > MAX_SIZE)
            {
                throw new ArgumentOutOfRangeException($"字符串{content}长度={len}，大于最大值({MAX_SIZE})");
            }

            return new String62
            {
                TotalLength = MAX_SIZE,
                EffectiveLength = (byte)content.Length,
                Content = content,
            };
        }
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class String126
    {
        private const int MAX_SIZE = 126;

        public byte TotalLength;
        public byte EffectiveLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SIZE)]
        public string Content;

        public String EffectiveContent
        {
            get => this.Content?.Substring(0, Math.Min(this.EffectiveLength, this.Content.Length));
            set
            {
                var v = String.IsNullOrEmpty(value) ? String.Empty : value;
                this.Content = v;
                this.TotalLength = MAX_SIZE;
                this.EffectiveLength = (byte)v.Length;
            }
        }

        public static String126 New(string content)
        {
            var len = content.Length;
            if (len > MAX_SIZE)
            {
                throw new ArgumentOutOfRangeException($"字符串{content}长度={len}，大于最大值({MAX_SIZE})");
            }

            return new String126
            {
                TotalLength = MAX_SIZE,
                EffectiveLength = (byte)content.Length,
                Content = content,
            };
        }
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class String254
    {
        private const int MAX_SIZE = 254;

        public byte TotalLength;
        public byte EffectiveLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SIZE)]
        public string Content;

        public String EffectiveContent
        {
            get => this.Content?.Substring(0, Math.Min(this.EffectiveLength, this.Content.Length));
            set
            {
                var v = String.IsNullOrEmpty(value) ? String.Empty : value;
                this.Content = v;
                this.TotalLength = MAX_SIZE;
                this.EffectiveLength = (byte)v.Length;
            }
        }

        public static String254 New(string content)
        {
            var len = content.Length;
            if (len > MAX_SIZE)
            {
                throw new ArgumentOutOfRangeException($"字符串{content}长度={len}，大于最大值({MAX_SIZE})");
            }

            return new String254
            {
                TotalLength = MAX_SIZE,
                EffectiveLength = (byte)content.Length,
                Content = content,
            };
        }
    }
}
