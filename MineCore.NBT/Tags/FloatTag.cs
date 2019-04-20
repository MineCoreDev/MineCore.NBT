using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class FloatTag : DataTag<float>
    {
        public override NBTTagType Type { get; } = NBTTagType.FLOAT;

        public FloatTag(float data) : base(data)
        {

        }

        public FloatTag(string name, float data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteFloatTag(this.Data);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadFloatTag();
        }
    }
}
