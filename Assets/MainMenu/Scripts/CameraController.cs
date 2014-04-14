using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    public Transform Target;

    [Range(0, 1)]
    public float Speed;

    void Update()
    {
        transform.LookAt(Target);
        transform.Translate(Vector3.right * Speed);
    }
}
