using System;
using System.Collections.Generic;

namespace DottweenExample
{
    public static class Extensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
            {
                action(obj);
            }

            return source;
        }
    }
}
