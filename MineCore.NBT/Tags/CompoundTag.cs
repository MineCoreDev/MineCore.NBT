using System.Collections.Generic;
using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class CompoundTag : Tag
    {
        public override NBTTagType Type { get; } = NBTTagType.COMPOUND;

        readonly Dictionary<string, Tag> tags = new Dictionary<string, Tag>();

        public CompoundTag(string name) : base(name)
        {

        }

        public byte GetByte(string name)
        {
            return ((ByteTag) this.tags[name]).Data;
        }

        public void SetByte(string name, byte data)
        {
            this.tags[name] = new ByteTag(name, data);
        }

        public short GetShort(string name)
        {
            return ((ShortTag) this.tags[name]).Data;
        }

        public void SetShort(string name, short data)
        {
            this.tags[name] = new ShortTag(name, data);
        }

        public int GetInt(string name)
        {
            return ((IntTag) this.tags[name]).Data;
        }

        public void SetInt(string name, int data)
        {
            this.tags[name] = new IntTag(name, data);
        }

        public long GetLong(string name)
        {
            return ((LongTag) this.tags[name]).Data;
        }

        public void SetLong(string name, long data)
        {
            this.tags[name] = new LongTag(name, data);
        }

        public float GetFloat(string name)
        {
            return ((FloatTag) this.tags[name]).Data;
        }

        public void SetFloat(string name, float data)
        {
            this.tags[name] = new FloatTag(name, data);
        }

        public double GetDouble(string name)
        {
            return ((DoubleTag) this.tags[name]).Data;
        }

        public void SetDouble(string name, double data)
        {
            this.tags[name] = new DoubleTag(name, data);
        }

        public string GetString(string name)
        {
            return ((StringTag) this.tags[name]).Data;
        }

        public void SetString(string name, string data)
        {
            this.tags[name] = new StringTag(name, data);
        }

        public byte[] GetByteArray(string name)
        {
            return ((ByteArrayTag) this.tags[name]).Data;
        }

        public void SetByteArray(string name, byte[] data)
        {
            this.tags[name] = new ByteArrayTag(name, data);
        }

        public int[] GetIntArray(string name)
        {
            return ((IntArrayTag) this.tags[name]).Data;
        }

        public void SetIntArray(string name, int[] data)
        {
            this.tags[name] = new IntArrayTag(name, data);
        }

        public long[] GetLongArray(string name)
        {
            return ((LongArrayTag) this.tags[name]).Data;
        }

        public void SetLongArray(string name, long[] data)
        {
            this.tags[name] = new LongArrayTag(name, data);
        }

        public ListTag GetList(string name)
        {
            return (ListTag) this.tags[name];
        }

        public void SetList(string name, ListTag tag)
        {
            this.tags[name] = tag;
        }

        public CompoundTag GetCompound(string name)
        {
            return (CompoundTag) this.tags[name];
        }

        public void SetCompound(string name, CompoundTag tag)
        {
            this.tags[name] = tag;
        }

        public Tag GetTag(string name)
        {
            return this.tags[name];
        }

        public void SetTag(string name, Tag tag)
        {
            this.tags[name] = tag;
        }

        public void Remove(string name)
        {
            this.tags.Remove(name);
        }

        public bool Exist(string name)
        {
            return this.tags.ContainsKey(name);
        }

        public bool Exist(string name, NBTTagType type)
        {
            return this.tags.ContainsKey(name) && this.tags[name].Type == type;
        }

        public int Count
        {
            get
            {
                return this.tags.Count;
            }
        }

        public Tag this[string name]
        {
            get
            {
                return this.GetTag(name);
            }

            set
            {
                this.SetTag(name, value);
            }
        }

        public Dictionary<string, Tag> Tags
        {
            get
            {
                return this.tags;
            }
        }
    }
}
