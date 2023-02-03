using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Helper.Utils
{

    public enum SeekType
    {
        Begin,
        End
    }

    public class Binary
    {
        public byte[] Source;
        public int Position = 0;

        public byte[] ReadBytes(int count)
        {
            var value = new byte[count];
            Array.Copy(Source, Position, value, 0, count);
            Position += count;
            return value;
        }


        public Binary Seek(int offset = 0, SeekType seekType = SeekType.End)
        {
            switch (seekType)
            {
                case SeekType.Begin:
                    Position = 0 + offset;
                    break;

                case SeekType.End:
                    Position = Source.Length - offset;
                    break;
            }

            return this;
            
        }

        public short ReadInt16()
        {
            var value = BitConverter.ToInt16(Source, Position);
            Position += sizeof(short);
            return value;
        }

        public int ReadInt32()
        {
            var value = BitConverter.ToInt32(Source, Position);
            Position += sizeof(int);
            return value;
        }

        public void Clear()
        {
            Source = new byte[] { };
            Position = 0;
        }

        public byte[] FillArray(byte[] value, int size)
        {
            var target = new byte[size];
            Array.Copy(value, target, target.Length >= value.Length ? value.Length : target.Length);
            return target;
        }

        internal void FileStream(string path)
        {
            Source = File.ReadAllBytes(path);
        }
    }
}
