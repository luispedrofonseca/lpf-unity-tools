using UnityEngine;
using System.Collections;
using System;

public static class GrabScreenshot
{
    public static IEnumerator Grab(
        Action<Texture2D> onScreenshotComplete, 
        Camera targetCamera = null,
        int textureWidth = 512, 
        int textureHeight = 512, 
        TextureFormat textureFormat = TextureFormat.RGBAHalf)
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        if (targetCamera == null)
        {
            Debug.LogError("No target camera defined");
            yield break;
        }

        //Wait for graphics to render
        yield return new WaitForEndOfFrame();

        RenderTexture rt = new RenderTexture(textureWidth, textureHeight, 24);        
        Texture2D screenShot = new Texture2D(textureWidth, textureHeight, textureFormat, false);

        targetCamera.targetTexture = rt;
        targetCamera.Render();
        targetCamera.targetTexture = null;

        RenderTexture.active = rt;        
        screenShot.ReadPixels(new Rect(0, 0, textureWidth, textureHeight), 0, 0);
        targetCamera.targetTexture = null;
        RenderTexture.active = null; //Added to avoid errors

        // Call the delegate
        onScreenshotComplete(screenShot);

        // Wait one frame for destroying the created textures
        yield return null;

        // Destroy
        GameObject.Destroy(rt);
        GameObject.Destroy(screenShot);
    }
}