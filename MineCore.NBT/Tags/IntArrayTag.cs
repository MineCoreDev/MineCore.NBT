using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class IntArrayTag : ArrayDataTag<int>
    {
        public override NBTTagType Type { get; } = NBTTagType.INT_ARRAY;

        public IntArrayTag(string name, int[] data) : base(name, data)
        {

        }
    }
}
