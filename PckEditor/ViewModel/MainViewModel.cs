using Helper.FilePackage;
using PckEditor.ModalWindow;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PckEditor.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class MainViewModel
    {
        private FilePackage packages;
        public ICollectionView Files { get; set; }
        public long ReadTime { get; set; }
        private FileEntry _selectFile;

        public FileEntry SelectFile { get => _selectFile; set
            {
                _selectFile = value;
                var file = packages.GetFile(SelectPacketEntry, _selectFile);
                var win = new TextFile(file);
                win.ShowDialog();
            }
        }

        public PacketEntry SelectPacketEntry { get; set; }

        public MainViewModel() {
            var timer = new Stopwatch();
            timer.Start();
            packages = new FilePackage();


            packages.Open("E:\\pw155\\element\\configs.pck");

            timer.Stop();
            ReadTime = timer.ElapsedMilliseconds;
            SelectPacketEntry = packages.Pcks[0];

            Files = CollectionViewSource.GetDefaultView(SelectPacketEntry.Items);
        }
    }
}
