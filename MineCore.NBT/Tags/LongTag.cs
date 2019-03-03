using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class LongTag : DataTag<long>
    {
        public override NBTTagType Type { get; } = NBTTagType.LONG;

        public LongTag(string name, long data) : base(name, data)
        {

        }
    }
}
