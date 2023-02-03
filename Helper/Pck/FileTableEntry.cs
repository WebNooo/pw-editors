using System;
using System.Runtime.InteropServices;

namespace Helper.Pck
{
    [StructLayout(LayoutKind.Sequential)]
    public class FileTableEntry
    {
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public string FilePatch { get; set; }
        //public byte[] FilePatch;
        public uint FileDataOffset { get; set; }
        public int FileDataDecompressedSize { get; set; }
        public int FileDataCompressedSize { get; set; }
    }
}

