using UnityEngine;
using System.Collections;

public class EaseHelper
{
    public static float IncrementTowards(float n, float target, float speed, float friction = 1f) 
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