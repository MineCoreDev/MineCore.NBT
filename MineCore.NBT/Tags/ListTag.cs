using System;
using System.Collections.Generic;
using MineCore.NBT.Data;
using MineCore.NBT.IO;

namespace MineCore.NBT.Tags
{
    public class ListTag : Tag
    {
        public override NBTTagType Type { get; } = NBTTagType.LIST;

        public NBTTagType ListTagType { get; private set; }

        public List<Tag> Tags { get; } = new List<Tag>();

        public ListTag(NBTTagType type, params object[] obj) : this("", type, obj)
        {

        }

        public ListTag(string name, NBTTagType type, params object[] obj) : base(name)
        {
            this.ListTagType = type;

            for (int i = 0; i < obj.Length; ++i)
            {
                this.Add(obj);
            }
        }

        public void Add(Tag tag)
        {
            if (this.ListTagType != tag.Type)
            {
                throw new FormatException();
            }
            this.Tags.Add(tag);
        }

        public void Add(object obj)
        {
            Tag tag;
            switch (obj)
            {
                case Tag t:
                    tag = t;
                    break;
                case byte b:
                    tag = new ByteTag(b);
                    break;
                case short s:
                    tag = new ShortTag(s);
                    break;
                case int i:
                    tag = new IntTag(i);
                    break;
                case long l:
                    tag = new LongTag(l);
                    break;
                case float f:
                    tag = new FloatTag(f);
                    break;
                case double d:
                    tag = new DoubleTag(d);
                    break;
                case byte[] b:
                    tag = new ByteArrayTag(b);
                    break;
                case string s:
                    tag = new StringTag(s);
                    break;
                case int[] i:
                    tag = new IntArrayTag(i);
                    break;
                case long[] l:
                    tag = new LongArrayTag(l);
                    break;
                default:
                    throw new FormatException();
            }

            this.Add(tag);
        }

        public void Remove(Tag tag)
        {
            this.Tags.Remove(tag);
        }

        public void RemoveAt(int index)
        {
            this.Tags.RemoveAt(index);
        }

        public T GetTag<T>(int index) where T : Tag
        {
            return (T) this.Tags[index];
        }

        public bool Exist(Tag tag)
        {
            return this.Tags.Contains(tag);
        }

        public int Count
        {
            get
            {
                return this.Tags.Count;
            }
        }

        public Tag this[int index]
        {
            get
            {
                return this.Tags[index];
            }

            set
            {
                if (this.ListTagType != value.Type)
                {
                    throw new FormatException();
                }
                this.Tags[index] = value;
            }
        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteByteTag((byte) this.ListTagType);
            stream.WriteIntTag(this.Tags.Count);
            for (int i = 0; i < this.Tags.Count; ++i)
            {
                this.Tags[i].Write(stream);
            }
        }

        internal override void Read(NBTStream stream)
        {
            this.ListTagType = (NBTTagType) stream.ReadByteTag();
            for (int i = 0; i < stream.ReadIntTag(); ++i)
            {
                Tag tag = null;
                switch (this.ListTagType)
                {
                    case NBTTagType.BYTE:
                        tag = new ByteTag(0);
                        break;

                    case NBTTagType.SHORT:
                        tag = new ShortTag(0);
                        break;

                    case NBTTagType.INT:
                        tag = new IntTag(0);
                        break;

                    case NBTTagType.LONG:
                        tag = new LongTag(0);
                        break;

                    case NBTTagType.FLOAT:
                        tag = new FloatTag(0);
                        break;

                    case NBTTagType.DOUBLE:
                        tag = new DoubleTag(0);
                        break;

                    case NBTTagType.BYTE_ARRAY:
                        tag = new ByteArrayTag(new byte[0]);
                        break;

                    case NBTTagType.STRING:
                        tag = new StringTag("");
                        break;

                    case NBTTagType.LIST:
                        tag = new ListTag(NBTTagType.END);
                        break;

                    case NBTTagType.COMPOUND:
                        tag = new CompoundTag();
                        break;

                    case NBTTagType.INT_ARRAY:
                        tag = new IntArrayTag(new int[0]);
                        break;

                    case NBTTagType.LONG_ARRAY:
                        tag = new LongArrayTag(new long[0]);
                        break;

                    default:
                        throw new NotSupportedException();
                }

                tag.Read(stream);
                this.Tags.Add(tag);
            }
        }
    }
}
