using System.Collections;

public static class StringExtension 
{
	public static string Remove(this string source, string remove,  int firstN)
	{
		if(firstN <= 0 || string.IsNullOrEmpty(source) || string.IsNullOrEmpty(remove))
		{
			return source;
		}
		int index = source.IndexOf(remove);
		return index < 0 ? source : source.Remove(index, remove.Length).Remove(remove, --firstN);
	}

	public static string ReplaceFirst(this string text, string search, string replace)
	{
		int pos = text.IndexOf(search);
		if (pos < 0)
		{
			return text;
		}
		return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
	}
}
