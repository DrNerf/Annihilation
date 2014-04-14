using UnityEngine;
using System.Collections;

public class CustomCharacterMotor : MonoBehaviour 
{
    [Range(0, 30)]
    public float Speed = 3.0f;
    [Range(0, 30)]
    public float RotationSpeed = 3.0f;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        CharacterController Controller = GetComponent<CharacterController>();

        transform.Rotate(0, Input.GetAxis("Horizontal") * RotationSpeed, 0);

        Vector3 Forward = transform.forward;
        var CurSpeed = 2 * Speed * Input.GetAxis("Vertical");
        Controller.SimpleMove(Forward * CurSpeed);
	}
}
