using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public abstract class DataTag<T> : Tag
    {
        public T Data { get; set; }

        public DataTag(string name, T data) : base(name)
        {
            this.Data = data;
        }

        public override string ToString()
        {
            return $"Type: {this.Type.ToNameString()}, Value: {this.Data}";
        }
    }
}
