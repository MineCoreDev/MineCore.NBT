using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class ByteArrayTag : ArrayDataTag<byte>
    {
        public override NBTTagType Type { get; } = NBTTagType.BYTE_ARRAY;

        public ByteArrayTag(byte[] data) : base(data)
        {

        }

        public ByteArrayTag(string name, byte[] data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            int len = this.Data.Length;
            stream.WriteIntTag(len);
            for (int i = 0; i < len; ++i)
            {
                stream.WriteByteTag(this.Data[i]);
            }
        }

        internal override void Read(NBTStream stream)
        {
            int len = stream.ReadIntTag();
            this.Data = new byte[len];
            for (int i = 0; i < len; ++i)
            {
                this.Data[i] = stream.ReadByteTag();
            }
        }
    }
}
