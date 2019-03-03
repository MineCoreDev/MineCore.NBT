using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class IntTag : DataTag<int>
    {
        public override NBTTagType Type { get; } = NBTTagType.INT;

        public IntTag(string name, int data) : base(name, data)
        {

        }
    }
}
