using MineCore.NBT.Data;

using Newtonsoft.Json;

namespace MineCore.NBT.Tags
{
    public abstract class Tag
    {
        public abstract NBTTagType Type { get; }

        public string Name { get; set; }

        public Tag(string name)
        {
            this.Name = name;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
