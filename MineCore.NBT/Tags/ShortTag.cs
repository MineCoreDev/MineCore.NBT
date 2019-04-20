using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class ShortTag : DataTag<short>
    {
        public override NBTTagType Type { get; } = NBTTagType.SHORT;

        public ShortTag(short data) : base(data)
        {

        }

        public ShortTag(string name, short data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteShortTag(this.Data);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadShortTag();
        }
    }
}
