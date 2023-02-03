using Helper.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Helper.Pck
{
    public class PckEntry
    {
        public string FilePath { get; set; }

        public ObservableCollection<FileTableEntry> Items = new ObservableCollection<FileTableEntry>();

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
