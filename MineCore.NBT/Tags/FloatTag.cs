using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class FloatTag : DataTag<float>
    {
        public override NBTTagType Type { get; } = NBTTagType.FLOAT;

        public FloatTag(string name, float data) : base(name, data)
        {

        }
    }
}
