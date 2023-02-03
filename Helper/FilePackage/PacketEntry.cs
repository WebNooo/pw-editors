using Helper.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Helper.FilePackage
{
    public class PacketEntry
    {
        public string FilePath { get; set; }

        public ObservableCollection<FileEntry> Items = new ObservableCollection<FileEntry>();

        public Binary Binary { get; set; }

        public int FilesCount { get; set; }
        public int FileTableOffset { get; set; }


    //Keys
        public int Key1 { get; set; }
        public int Key2 { get; set; }
        public int Asig1 { get; set; }
        public int Asig2 { get; set; }
        public int Fsig1 { get; set; }
        public int Fsig2 { get; set; }

    }
}
