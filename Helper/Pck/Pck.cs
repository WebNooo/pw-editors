using Helper.Utils;
using Ionic.Zlib;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Helper.Pck
{
    public class Pck
    {

        public ObservableCollection<PckEntry> Pcks = new ObservableCollection<PckEntry>();

        public Pck()
        {
        }

        public void Open(string path)
        {
            var pckEntry = new PckEntry() 
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

                byte[] buffer;
                if (entrySize < 276)
                {

                    buffer = ZlibStream.UncompressBuffer(pckEntry.Binary.ReadBytes(entrySize));
                }
                else
                {
                    buffer = pckEntry.Binary.ReadBytes(entrySize);
                }

                var binary = new Binary() { Source = buffer };

                var fileTableEntry = new FileTableEntry();
                fileTableEntry.FilePatch = Encoding.GetEncoding("GB2312").GetString(binary.ReadBytes(260)).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("/", "\\");
                fileTableEntry.FileDataOffset = (uint)binary.ReadInt32();
                fileTableEntry.FileDataDecompressedSize = binary.ReadInt32();
                fileTableEntry.FileDataCompressedSize = binary.ReadInt32();

                pckEntry.Items.Add(fileTableEntry);

            }

            Pcks.Add(pckEntry);



        }

        public void Save()
        {

        }
    }
}

