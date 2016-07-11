// https://twitter.com/AngryAnt/status/751721482531774464

using System.Collections.Generic;

public static class ListExtension
{
    public static T AddAndReturn<T>(this List<T> list, T item)
    {
        list.Add(item);
        return item;
    }
}