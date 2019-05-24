using UnityEngine;

public static class RectExtension
{
	public static Vector2 RandomPositionInside(this Rect rect)
	{
		return new Vector2(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax));
	}
}
