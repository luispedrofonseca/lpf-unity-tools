using System.Collections;
using System.Text;

public static class EnumerableExtension
{
    public static string DeepToString(this IEnumerable collection)
    {
        if (collection == null)
            return "null";

        StringBuilder text = new StringBuilder();

        int i = 0;
        foreach (object item in collection)
        {
            text.AppendLine();
            text.Append('[');
            text.Append(i);
            text.Append("] = ");
            text.Append(item);

            i++;
        }

        text.Insert(0, i);

        return text.ToString();
    }
}