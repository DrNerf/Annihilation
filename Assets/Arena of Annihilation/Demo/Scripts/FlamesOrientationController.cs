using UnityEngine;
using System.Collections;

public class FlamesOrientationController : MonoBehaviour 
{
    public Transform FlameEffect;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        FlameEffect.up = Vector3.back;
	}
}
