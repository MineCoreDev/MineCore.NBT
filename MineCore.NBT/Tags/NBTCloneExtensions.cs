using System;

namespace MineCore.NBT.Tags
{
    public static class NBTCloneExtensions
    {
        public static T Copy<T>(this T obj) where T : Tag, ICloneable
        {
            return (T) obj.Clone();
        }
    }
}
