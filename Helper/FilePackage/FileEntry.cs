using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Helper.FilePackage
{
    [StructLayout(LayoutKind.Sequential)]
    public class FileEntry
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        private byte[] name;
        //	The file name of this entry; this may contain a path;
        public string FileName { get => Encoding.GetEncoding("GBK").GetString(name); set => name = new byte[1]; }                                         
        //	The offset from the beginning of the package file;
        public int Offset { get; set; }                                              
        //	The length of this file;
        public int Length { get; set; }
        //	The compressed data length;
        public int CompressedLength { get; set; }                                
        //	Access counter used by OpenSharedFile
        public int iAccessCnt { get; set; }
    }
}
