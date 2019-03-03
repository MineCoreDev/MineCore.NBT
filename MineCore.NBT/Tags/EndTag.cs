using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class EndTag : Tag
    {
        public override NBTTagType Type { get; } = NBTTagType.END;

        public EndTag() : base(null)
        {

        }
    }
}
