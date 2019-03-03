using System;
using System.Collections.Generic;
using MineCore.NBT.Data;

namespace MineCore.NBT.Tags
{
    public class ListTag : Tag
    {
        public override NBTTagType Type { get; } = NBTTagType.LIST;

        readonly List<Tag> tags = new List<Tag>();

        public NBTTagType ListTagType { get; }

        public ListTag(string name, NBTTagType type) : base(name)
        {
            this.ListTagType = type;
        }

        public void Add(Tag tag)
        {
            if (this.ListTagType != tag.Type)
            {
                throw new FormatException();
            }
            this.tags.Add(tag);
        }

        public void Remove(Tag tag)
        {
            this.tags.Remove(tag);
        }

        public void RemoveAt(int index)
        {
            this.tags.RemoveAt(index);
        }

        public T GetTag<T>(int index) where T : Tag
        {
            return (T) this.tags[index];
        }

        public bool Exist(Tag tag)
        {
            return this.tags.Contains(tag);
        }

        public int Count
        {
            get
            {
                return this.tags.Count;
            }
        }

        public Tag this[int index]
        {
            get
            {
                return this.tags[index];
            }

            set
            {
                if (this.ListTagType != value.Type)
                {
                    throw new FormatException();
                }
                this.tags[index] = value;
            }
        }

        public List<Tag> Tags
        {
            get
            {
                return this.tags;
            }
        }
    }
}
