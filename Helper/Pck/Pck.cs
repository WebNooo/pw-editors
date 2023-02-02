using Helper.Utils;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Helper.Pck
{
    public class Pck
    {

        public ObservableCollection<PckEntry> Pcks = new ObservableCollection<PckEntry>();

        public Pck()
        {
        }

        public void Open(string filePath)
        {
            var pckEntry = new PckEntry() 
            { 
                FilePath = filePath, 
                Binary = new Binary(), 
                Key1 = -1466731422, 
                Key2 = -240896429,
                Asig1 = -33685778,
                Asig2 = -267534609,
                Fsig1 = 1305093103,
                Fsig2 = 1453361591,
            };

            pckEntry.Binary.Source = File.ReadAllBytes(pckEntry.FilePath);
            pckEntry.FilesCount = pckEntry.Binary.Seek(8, SeekType.End).ReadInt32();
            pckEntry.FileTableOffset = (int)((uint)((uint)pckEntry.Binary.Seek(272, SeekType.End).ReadInt32() ^ (ulong)pckEntry.Key1));


            pckEntry.Binary.Seek(pckEntry.FileTableOffset, SeekType.Begin);

            for (int i = 0; i < pckEntry.FilesCount; i++)
            {
                pckEntry.Binary.ReadInt32();
                var entrySize = pckEntry.Binary.ReadInt32() ^ pckEntry.Key2;
                if (entrySize < 276)
                {

                }

            }
           

        }

        public void Save()
        {

        }
    }
}

