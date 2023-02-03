using Helper.Utils;
using Ionic.Zlib;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Helper.FilePackage
{
    public class FilePackage
    {

        public ObservableCollection<PacketEntry> Pcks = new ObservableCollection<PacketEntry>();

        public FilePackage()
        {
        }

        public void Open(string path)
        {
            var pckEntry = new PacketEntry() 
            { 
                FilePath = path, 
                Binary = new Binary(),
                Key1 = -1466731422, 
                Key2 = -240896429,
                Asig1 = -33685778,
                Asig2 = -267534609,
                Fsig1 = 1305093103,
                Fsig2 = 1453361591,
            };

            pckEntry.Binary.FileStream(pckEntry.FilePath);
            pckEntry.FilesCount = pckEntry.Binary.Seek(8, SeekType.End).ReadInt32();
            pckEntry.FileTableOffset = (int)((uint)((uint)pckEntry.Binary.Seek(272, SeekType.End).ReadInt32() ^ (ulong)pckEntry.Key1));


            pckEntry.Binary.Seek(pckEntry.FileTableOffset, SeekType.Begin);

            for (int i = 0; i < pckEntry.FilesCount; i++)
            {
                var test = pckEntry.Binary.ReadInt32() ^ pckEntry.Key1;
                var entrySize = pckEntry.Binary.ReadInt32() ^ pckEntry.Key2;

                byte[] bytes;
                if (entrySize < 276)
                {

                    bytes = ZlibStream.UncompressBuffer(pckEntry.Binary.ReadBytes(entrySize));
                }
                else
                {
                    bytes = pckEntry.Binary.ReadBytes(entrySize);
                }

                var size = Marshal.SizeOf(typeof(FileEntry));
                IntPtr buffer = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, buffer, size);
                var fields = Marshal.PtrToStructure(buffer, typeof(FileEntry)) as FileEntry;




                
                //fileTableEntry.FilePatch = Encoding.GetEncoding("GB2312").GetString(binary.ReadBytes(260)).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("/", "\\");
                //fileTableEntry.FileDataOffset = (uint)binary.ReadInt32();
                //fileTableEntry.FileDataDecompressedSize = binary.ReadInt32();
                //fileTableEntry.FileDataCompressedSize = binary.ReadInt32();

                pckEntry.Items.Add(fields);

            }

            Pcks.Add(pckEntry);



        }

        public string GetFile(PacketEntry package, FileEntry file)
        {

           byte[] fileBuffer = package.Binary
                    .Seek(file.Offset, SeekType.Begin)
                    .ReadBytes(file.CompressedLength);



            return Encoding.GetEncoding(866).GetString(ZlibStream.UncompressBuffer(fileBuffer));


        }

        private void ReadSafeHeader()
        {

        }

        public void Save()
        {

        }

        public void GetFile()
        {

        }

        public void AppendFile()
        {

        }

        public void RemoveFile()
        {

        }
    }
}

