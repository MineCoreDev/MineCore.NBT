using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class LongArrayTag : ArrayDataTag<long>
    {
        public override NBTTagType Type { get; } = NBTTagType.LONG_ARRAY;

        public LongArrayTag(string name, long[] data) : base(name, data)
        {

        }
    }
}
