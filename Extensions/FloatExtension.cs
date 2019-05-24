using UnityEngine;

public static class FloatExtension
{
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return Mathf.Clamp((value - from1) / (to1 - from1) * (to2 - from2) + from2, from2, to2);
    }
    
    public static float RemapAndClamp(this float value, float from1, float to1, float from2, float to2)
    {
        return value.Remap(from1, to1, from2, to2).Clamp(from2, to2);
    }
    
    public static float Clamp(this float value, float min, float max)
    {
        return Mathf.Clamp(value, min, max);
    }
}