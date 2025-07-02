using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Bismuth.Utilities
{
    public static class Extensions
    {
        public static Dictionary<Texture2D, Color> averageColorCache = new Dictionary<Texture2D, Color>();
        public const byte unsafeAdd = 128;
        public const byte unsafeRemove = 127;

        public static void Initialize()
        {
        }
        public static int IndexWhere(this string str, Func<char, bool> func)
        {
            for (int index = 0; index < str.Length; ++index)
            {
                if (func(str[index]))
                    return index;
            }
            return -1;
        }
        public static bool IndexWhere(this string str, Func<char, bool> func, out int index)
        {
            for (int index1 = 0; index1 < str.Length; ++index1)
            {
                if (func(str[index1]))
                {
                    index = index1;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        public static int IndexWhere<T>(this List<T> list, Func<T, bool> predicate)
        {
            for (int index = 0; index < list.Count; ++index)
            {
                if (predicate(list[index]))
                    return index;
            }
            return -1;
        }
    }
}
