using UnityEngine;
using System.Collections;

public class CameraControl : Photon.MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        if (photonView.isMine)
        {
            Camera.main.gameObject.AddComponent<SmoothFollow>();
            SmoothFollow Follow = Camera.main.gameObject.GetComponent<SmoothFollow>();
            Follow.target = transform;
            Follow.height = 1.3f;
            Follow.rotationDamping = 100;
            Follow.distance = 4.7f;
            Follow.heightDamping = 100;
        }
	}
}
