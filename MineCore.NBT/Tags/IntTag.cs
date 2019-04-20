using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class IntTag : DataTag<int>
    {
        public override NBTTagType Type { get; } = NBTTagType.INT;

        public IntTag(int data) : base(data)
        {

        }

        public IntTag(string name, int data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteIntTag(this.Data);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadIntTag();
        }
    }
}
