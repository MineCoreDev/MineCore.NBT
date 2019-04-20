using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class LongArrayTag : ArrayDataTag<long>
    {
        public override NBTTagType Type { get; } = NBTTagType.LONG_ARRAY;

        public LongArrayTag(long[] data) : base(data)
        {

        }

        public LongArrayTag(string name, long[] data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            int len = this.Data.Length;
            stream.WriteIntTag(len);
            for (int i = 0; i < len; ++i)
            {
                stream.WriteLongTag(this.Data[i]);
            }
        }

        internal override void Read(NBTStream stream)
        {
            int len = stream.ReadIntTag();
            this.Data = new long[len];
            for (int i = 0; i < len; ++i)
            {
                this.Data[i] = stream.ReadLongTag();
            }
        }
    }
}
