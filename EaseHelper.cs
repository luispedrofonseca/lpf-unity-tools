using UnityEngine;
using System.Collections;

public class EaseHelper
{
    public static float IncrementTowards(float n, float target, float speed, float deltaTime, float friction = 1f) 
	{
		if (n == target) 
		{
			return n;	
		}
		else 
		{
			float dir = Mathf.Sign(target - n);
			n += speed * deltaTime * dir * friction * friction;
			return (dir == Mathf.Sign(target-n))? n: target;
		}
	}

	public static float InterpolateOverCurve(AnimationCurve curve, float from, float to, float t)
	{
		return from + curve.Evaluate(t) * (to - from);
	}
}