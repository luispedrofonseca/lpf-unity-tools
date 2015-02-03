using UnityEngine;
using System.Collections;

public class EaseHelper
{
	public static float IncrementTowards(float n, float target, float speed) 
	{
		if (n == target) 
		{
			return n;	
		}
		else 
		{
			float dir = Mathf.Sign(target - n);
			n += speed * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target;
		}
	}

	public static float IncrementTowards(float n, float target, float speed, float friction) 
	{
		if (n == target) 
		{
			return n;	
		}
		else 
		{
			float dir = Mathf.Sign(target - n);
			n += speed * Time.deltaTime * dir * friction * friction;
			return (dir == Mathf.Sign(target-n))? n: target;
		}
	}
}