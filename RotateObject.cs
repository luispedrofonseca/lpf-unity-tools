using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Space Space = Space.World;
    public Vector3 Speed = Vector3.one;

    Transform _transform;

    void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.Rotate(Speed * Time.smoothDeltaTime, Space);
    }
}