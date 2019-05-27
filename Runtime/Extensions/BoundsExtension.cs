using UnityEngine;

public static class BoundsExtension
{
	public static bool ContainsBounds(this Bounds bounds, Bounds target)
	{
		return bounds.Contains(target.min) && bounds.Contains(target.max);
	}
	
	public static Vector3 RandomPointInside(this Bounds bounds) 
	{
		return bounds.center + new Vector3 (
			       (Random.value - 0.5f) * bounds.size.x,
			       (Random.value - 0.5f) * bounds.size.y,
			       (Random.value - 0.5f) * bounds.size.z
		       );
	}
}