using System;
using MineCore.NBT.Data;
using MineCore.NBT.IO;
using Newtonsoft.Json;

namespace MineCore.NBT.Tags
{
    public abstract class Tag : ICloneable
    {
        public abstract NBTTagType Type { get; }

        public string Name { get; set; }

        public Tag(string name = "")
        {
            if (name == null)
            {
                name = "";
            }
            this.Name = name;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal abstract void Write(NBTStream stream);

        internal void WriteTag(NBTStream stream)
        {
            stream.WriteByteTag((byte) this.Type);
            stream.WriteStringTag(this.Name);
            this.Write(stream);
        }

        internal abstract void Read(NBTStream stream);

        internal void ReadTag(NBTStream stream)
        {
            stream.ReadByteTag();
            string name = stream.ReadStringTag();
            this.Read(stream);
        }
    }
}
