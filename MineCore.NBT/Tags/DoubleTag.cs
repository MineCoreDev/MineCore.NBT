using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class DoubleTag : DataTag<double>
    {
        public override NBTTagType Type { get; } = NBTTagType.DOUBLE;

        public DoubleTag(double data) : base(data)
        {

        }
        
        public DoubleTag(string name, double data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteDoubleTag(this.Data);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadDoubleTag();
        }
    }
}
