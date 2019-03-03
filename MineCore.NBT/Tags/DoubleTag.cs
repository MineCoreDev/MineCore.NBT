using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class DoubleTag : DataTag<double>
    {
        public override NBTTagType Type { get; } = NBTTagType.DOUBLE;
        
        public DoubleTag(string name, double data) : base(name, data)
        {

        }
    }
}
