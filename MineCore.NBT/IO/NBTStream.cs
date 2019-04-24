using BinaryIO;

namespace MineCore.NBT.IO
{
    public class NBTStream : NetworkStream
    {
        public ByteOrder ByteOrder { get; }

        public bool IsNetwork { get; }

        public NBTStream(ByteOrder order = ByteOrder.Little, bool isNetwork = false)
        {
            this.ByteOrder = order;
        }

        public NBTStream(byte[] buffer, ByteOrder order = ByteOrder.Little, bool isNetwork = false) : base(buffer)
        {
            this.ByteOrder = order;
        }

        public byte ReadByteTag()
        {
            return this.ReadByte();
        }

        public void WriteByteTag(byte value)
        {
            this.WriteByte(value);
        }

        public short ReadShortTag()
        {
            return this.ReadShort(this.ByteOrder);
        }

        public void WriteShortTag(short value)
        {
            this.WriteShort(value, this.ByteOrder);
        }

        public int ReadIntTag()
        {
            if (this.IsNetwork)
            {
                return this.ReadSVarInt();
            }
            else
            {
                return this.ReadInt(this.ByteOrder);
            }
        }

        public void WriteIntTag(int value)
        {
            if (this.IsNetwork)
            {
                this.WriteSVarInt(value);
            }
            else
            {
                this.WriteInt(value, this.ByteOrder);
            }
        }

        public long ReadLongTag()
        {
            if (this.IsNetwork)
            {
                return this.ReadSVarLong();
            }
            else
            {
                return this.ReadLong(this.ByteOrder);
            }
        }

        public void WriteLongTag(long value)
        {
            if (this.IsNetwork)
            {
                this.WriteSVarLong(value);
            }
            else
            {
                this.WriteLong(value, this.ByteOrder);
            }
        }

        public float ReadFloatTag()
        {
            return this.ReadFloat(this.ByteOrder);
        }

        public void WriteFloatTag(float value)
        {
            this.WriteFloat(value, this.ByteOrder);
        }

        public double ReadDoubleTag()
        {
            return this.ReadDouble(this.ByteOrder);
        }

        public void WriteDoubleTag(double value)
        {
            this.WriteDouble(value, this.ByteOrder);
        }

        public string ReadStringTag()
        {
            if (this.IsNetwork)
            {
                return this.ReadString();
            }
            else
            {
                return this.ReadStringUtf8(this.ByteOrder);
            }
        }

        public void WriteStringTag(string value)
        {
            if (this.IsNetwork)
            {
                this.WriteString(value);
            }
            else
            {
                this.WriteStringUtf8(value, this.ByteOrder);
            }
        }
    }
}
