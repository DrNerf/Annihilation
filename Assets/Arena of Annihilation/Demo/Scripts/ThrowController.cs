using UnityEngine;
using System.Collections;

public class ThrowController :  Photon.MonoBehaviour 
{
    [Range(1, 2000)]
    public int Force;
    public Transform ThrowPoint;
    public Transform Spear;
	// Use this for initialization
	void Start () 
    {
        Spear = GameObject.Find("Spear").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("SpecialAttack"))
        {
            Throw();
        }
	}

    void Throw()
    {
        Spear.parent = null;
        Spear.position = ThrowPoint.position;
        Spear.rotation = ThrowPoint.rotation;
        Spear.rigidbody.isKinematic = false;
        Spear.collider.enabled = true;
        Spear.rigidbody.AddForce(transform.forward * Force);
        gameObject.GetComponent<PickingUpController>().IsPickedUp = false;
    }
}
