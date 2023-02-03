using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.FilePackage
{
    public class FileEntryCache
    {
        int CompressedLength;   //	The compressed file entry length
        byte[] EntryCompressed;	//	The compressed file entry data
    }
}
