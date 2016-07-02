using UnityEngine;

public class SetFrameRate : MonoBehaviour 
{
    public int FrameRate = 60;

    void Awake()
    {
        Application.targetFrameRate = FrameRate;
    }
}