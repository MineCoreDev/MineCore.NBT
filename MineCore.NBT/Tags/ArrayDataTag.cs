﻿namespace MineCore.NBT.Tags
{
    public abstract class ArrayDataTag<T> : Tag
    {
        public T[] Data { get; set; }

        public ArrayDataTag(string name, T[] data) : base(name)
        {
            this.Data = data;
        }
    }
}
