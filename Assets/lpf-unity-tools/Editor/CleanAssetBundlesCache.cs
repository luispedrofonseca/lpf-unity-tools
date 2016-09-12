using UnityEngine;
using UnityEditor;

/// <summary>
/// An editor script which deletes cache info.
///
/// NOTE:
///     Delete all AssetBundle content that has been cached by the current application.
///     This function is not available to WebPlayer applications that use the shared cache.
///
/// See Also:
///     http://docs.unity3d.com/Documentation/ScriptReference/Caching.CleanCache.html
///
/// </summary>
/// 
public class CleanAssetBundlesCache
{
    [MenuItem ("Tools/Cache/Clean AssetBundle caches")]
    public static void CleanCache ()
    {
        if (Caching.CleanCache ()) 
        {
            Debug.LogWarning ("Successfully cleaned all AssetBundle caches.");
        }
        else 
        {
            Debug.LogWarning ("Cache was in use.");
        }
    }
}