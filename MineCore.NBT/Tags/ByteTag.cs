using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class ByteTag : DataTag<byte>
    {
        public override NBTTagType Type { get; } = NBTTagType.BYTE;

        public ByteTag(byte data) : base(data)
        {

        }

        public ByteTag(string name, byte data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteByteTag(this.Data);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadByteTag();
        }
    }
}
