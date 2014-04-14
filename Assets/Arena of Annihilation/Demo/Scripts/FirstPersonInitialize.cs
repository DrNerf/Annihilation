using UnityEngine;
using System.Collections;

public class FirstPersonInitialize : MonoBehaviour 
{
    public Transform FirstPersonCameraSpot;
	// Use this for initialization
	void Start () 
    {
        Transform TempCam = Camera.main.transform;
        TempCam.parent = FirstPersonCameraSpot;
        TempCam.localPosition = Vector3.zero;
        TempCam.localRotation = Quaternion.identity;
	}
}
