using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class StringTag : DataTag<string>
    {
        public override NBTTagType Type { get; } = NBTTagType.STRING;

        public StringTag(string name, string data) : base(name, data)
        {

        }
    }
}
