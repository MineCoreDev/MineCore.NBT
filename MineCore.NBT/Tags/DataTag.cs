namespace MineCore.NBT.Tags
{
    public abstract class DataTag<T> : Tag
    {
        public T Data { get; set; }

        public DataTag(T data)
        {
            this.Data = data;
        }

        public DataTag(string name, T data) : base(name)
        {
            this.Data = data;
        }
    }
}
