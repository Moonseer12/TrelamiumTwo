﻿using System.Collections.Generic;

namespace TrelamiumTwo.Utilities.Extensions
{
    internal static class GenericExtensions
    {
        public static bool TryInsert<T>(this List<T> tasks, int index, T item, int additive = 1) where T : class
        {
            if (index == -1)
                return false;

            tasks.Insert(index + additive, item);

            return true;
        }
    }
}