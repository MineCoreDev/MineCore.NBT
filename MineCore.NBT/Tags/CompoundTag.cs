using System;
using System.Collections.Generic;
using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class CompoundTag : Tag
    {
        public override NBTTagType Type { get; } = NBTTagType.COMPOUND;

        public Dictionary<string, Tag> Tags { get; } = new Dictionary<string, Tag>();

        public CompoundTag()
        {

        }

        public CompoundTag(string name) : base(name)
        {

        }

        public byte GetByte(string name)
        {
            return ((ByteTag) this.Tags[name]).Data;
        }

        public void SetByte(string name, byte data)
        {
            this.Tags[name] = new ByteTag(name, data);
        }

        public short GetShort(string name)
        {
            return ((ShortTag) this.Tags[name]).Data;
        }

        public void SetShort(string name, short data)
        {
            this.Tags[name] = new ShortTag(name, data);
        }

        public int GetInt(string name)
        {
            return ((IntTag) this.Tags[name]).Data;
        }

        public void SetInt(string name, int data)
        {
            this.Tags[name] = new IntTag(name, data);
        }

        public long GetLong(string name)
        {
            return ((LongTag) this.Tags[name]).Data;
        }

        public void SetLong(string name, long data)
        {
            this.Tags[name] = new LongTag(name, data);
        }

        public float GetFloat(string name)
        {
            return ((FloatTag) this.Tags[name]).Data;
        }

        public void SetFloat(string name, float data)
        {
            this.Tags[name] = new FloatTag(name, data);
        }

        public double GetDouble(string name)
        {
            return ((DoubleTag) this.Tags[name]).Data;
        }

        public void SetDouble(string name, double data)
        {
            this.Tags[name] = new DoubleTag(name, data);
        }

        public string GetString(string name)
        {
            return ((StringTag) this.Tags[name]).Data;
        }

        public void SetString(string name, string data)
        {
            this.Tags[name] = new StringTag(name, data);
        }

        public byte[] GetByteArray(string name)
        {
            return ((ByteArrayTag) this.Tags[name]).Data;
        }

        public void SetByteArray(string name, byte[] data)
        {
            this.Tags[name] = new ByteArrayTag(name, data);
        }

        public int[] GetIntArray(string name)
        {
            return ((IntArrayTag) this.Tags[name]).Data;
        }

        public void SetIntArray(string name, int[] data)
        {
            this.Tags[name] = new IntArrayTag(name, data);
        }

        public long[] GetLongArray(string name)
        {
            return ((LongArrayTag) this.Tags[name]).Data;
        }

        public void SetLongArray(string name, long[] data)
        {
            this.Tags[name] = new LongArrayTag(name, data);
        }

        public ListTag GetList(string name)
        {
            return (ListTag) this.Tags[name];
        }

        public CompoundTag GetCompound(string name)
        {
            return (CompoundTag) this.Tags[name];
        }

        public Tag GetTag(string name)
        {
            return this.Tags[name];
        }

        public void SetTag(Tag tag)
        {
            this.Tags[tag.Name] = tag;
        }

        public void Remove(string name)
        {
            this.Tags.Remove(name);
        }

        public bool Exist(string name)
        {
            return this.Tags.ContainsKey(name);
        }

        public bool Exist(string name, NBTTagType type)
        {
            return this.Tags.ContainsKey(name) && this.Tags[name].Type == type;
        }

        public int Count
        {
            get
            {
                return this.Tags.Count;
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
                this.SetTag(value);
            }
        }

        internal override void Write(NBTStream stream)
        {
            foreach (Tag t in this.Tags.Values)
            {
                t.WriteTag(stream);
            }
            stream.WriteByteTag((byte) NBTTagType.END);
        }

        internal override void Read(NBTStream stream)
        {
            while (stream.Position != stream.Length)
            {
                NBTTagType type = (NBTTagType) stream.ReadByteTag();
                String name = "";
                int len = 0;
                switch (type)
                {
                    case NBTTagType.END:
                        return;

                    case NBTTagType.BYTE:
                        this.SetByte(stream.ReadStringTag(), stream.ReadByteTag());
                        break;

                    case NBTTagType.SHORT:
                        this.SetShort(stream.ReadStringTag(), stream.ReadShortTag());
                        break;

                    case NBTTagType.INT:
                        this.SetInt(stream.ReadStringTag(), stream.ReadIntTag());
                        break;

                    case NBTTagType.LONG:
                        this.SetLong(stream.ReadStringTag(), stream.ReadLongTag());
                        break;

                    case NBTTagType.FLOAT:
                        this.SetFloat(stream.ReadStringTag(), stream.ReadFloatTag());
                        break;

                    case NBTTagType.DOUBLE:
                        this.SetDouble(stream.ReadStringTag(), stream.ReadDoubleTag());
                        break;

                    case NBTTagType.BYTE_ARRAY:
                        name = stream.ReadStringTag();
                        byte[] byteArray = new byte[stream.ReadIntTag()];
                        for (int i = 0; i < len; ++i)
                        {
                            byteArray[i] = stream.ReadByteTag();
                        }
                        this.SetByteArray(name, byteArray);
                        break;

                    case NBTTagType.STRING:
                        this.SetString(stream.ReadStringTag(), stream.ReadStringTag());
                        break;

                    case NBTTagType.LIST:
                        ListTag list = new ListTag(stream.ReadStringTag(), NBTTagType.END);
                        list.Read(stream);
                        this.SetTag(list);
                        break;

                    case NBTTagType.COMPOUND:
                        CompoundTag compound = new CompoundTag(stream.ReadStringTag());
                        compound.Read(stream);
                        this.SetTag(compound);
                        break;

                    case NBTTagType.INT_ARRAY:
                        name = stream.ReadStringTag();
                        int[] intArray = new int[stream.ReadIntTag()];
                        for (int i = 0; i < len; ++i)
                        {
                            intArray[i] = stream.ReadIntTag();
                        }
                        this.SetIntArray(name, intArray);
                        break;

                    case NBTTagType.LONG_ARRAY:
                        name = stream.ReadStringTag();
                        long[] longArray = new long[stream.ReadIntTag()];
                        for (int i = 0; i < len; ++i)
                        {
                            longArray[i] = stream.ReadLongTag();
                        }
                        this.SetLongArray(stream.ReadStringTag(), longArray);
                        break;

                    default:
                        throw new FormatException();
                }
            }
        }
    }
}
