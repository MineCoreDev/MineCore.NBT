using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class ByteTag : DataTag<byte>
    {
        public override NBTTagType Type { get; } = NBTTagType.BYTE;

        public ByteTag(string name, byte data) : base(name, data)
        {

        }
    }
}
