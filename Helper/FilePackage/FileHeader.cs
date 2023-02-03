using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.FilePackage
{
    public class FileHeader
    {
        public int GuardByte0;               //	0xabcdefab
        public int Version;                //	Composed by two word version, major part and minor part;
        public int EntryOffset;            //	The entry list offset from the beginning;
        public int Flags;              //	package flags. the highest bit means the encrypt state;
        public byte[] szDescription = new byte[252];        //	Description
        public int GuardByte1;				//	0xffeeffee
    }
}
