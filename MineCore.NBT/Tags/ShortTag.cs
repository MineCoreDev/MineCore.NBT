using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class ShortTag : DataTag<short>
    {
        public override NBTTagType Type { get; } = NBTTagType.SHORT;

        public ShortTag(string name, short data) : base(name, data)
        {

        }
    }
}
