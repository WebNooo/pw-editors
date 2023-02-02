using System;

namespace Helper.Pck
{
	public class FileTableEntry
	{
		public string FilePatch { get; set; }
        public int FileDataOffset { get; set; }
        public int FileDataDecompressedSize { get; set; }
        public int FileDataCompressedSize { get; set; }
    }
}

