using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class IntArrayTag : ArrayDataTag<int>
    {
        public override NBTTagType Type { get; } = NBTTagType.INT_ARRAY;

        public IntArrayTag(int[] data) : base(data)
        {

        }

        public IntArrayTag(string name, int[] data) : base(name, data)
        {

        }

        internal override void Write(NBTStream stream)
        {
            int len = this.Data.Length;
            stream.WriteIntTag(len);
            for (int i = 0; i < len; i++)
            {
                stream.WriteIntTag(this.Data[i]);
            }
        }

        internal override void Read(NBTStream stream)
        {
            int len = stream.ReadIntTag();
            this.Data = new int[len];
            for (int i = 0; i < len; i++)
            {
                this.Data[i] = stream.ReadIntTag();
            }
        }
    }
}
