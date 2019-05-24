// https://bitbucket.org/richardfine/scriptableobjectdemo/src/9a60686609a4?at=default

using System;

[Serializable]
public struct RangedFloat
{
	public float minValue;
	public float maxValue;

	public RangedFloat(float min, float max)
	{
		this.minValue = min;
		this.maxValue = max;
	}
}