using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class StringTag : DataTag<string>
    {
        public override NBTTagType Type { get; } = NBTTagType.STRING;

        public StringTag(string data) : base(data)
        {

        }

        public StringTag(string name, string data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteStringTag(this.Data);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadStringTag();
        }
    }
}
