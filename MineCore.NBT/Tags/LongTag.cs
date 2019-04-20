using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class LongTag : DataTag<long>
    {
        public override NBTTagType Type { get; } = NBTTagType.LONG;

        public LongTag(long data) : base(data)
        {

        }

        public LongTag(string name, long data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteLongTag(this.Data);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadLongTag();
        }
    }
}
