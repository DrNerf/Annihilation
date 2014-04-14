using UnityEngine;
using System.Collections;

public class DestroyGameObjectAfterTime : MonoBehaviour 
{
    public float Seconds = 0;

    void Start()
    {
        Invoke("Destroy", Seconds);
    }
    
    void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
