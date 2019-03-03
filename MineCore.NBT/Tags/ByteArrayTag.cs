using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class ByteArrayTag : ArrayDataTag<byte>
    {
        public override NBTTagType Type { get; } = NBTTagType.BYTE_ARRAY;

        public ByteArrayTag(string name, byte[] data) : base(name, data)
        {

        }
    }
}
