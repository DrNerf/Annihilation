using UnityEngine;
using System.Collections;

public class PickingUpController : Photon.MonoBehaviour 
{
    public Transform Spear;
    public bool IsPickedUp = false;
    public Transform Hand;
    public Transform DummySpear;

    private bool PickUpInRange;
    private GameObject PickedUpObject;

	// Use this for initialization
	void Start () 
    {
        Spear = GameObject.Find("Spear").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!this.IsPickedUp)
        {
            if (Input.GetButtonDown("PickUp"))
            {
                if (PickUpInRange)
                {
                    this.IsPickedUp = true;
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("PickUp", PhotonTargets.All);
                }
            }
        }

	}

    void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.tag == "PickedUp")
        {
            PickUpInRange = true;
        }
    }

    void OnTriggerExit(Collider Other)
    {

        if (Other.gameObject.tag == "PickedUp")
        {
            PickUpInRange = false;
        }
    }

    [RPC]
    void PickUp()
    {
        Spear.transform.parent = Hand;
        Spear.rigidbody.isKinematic = true;
        Spear.collider.enabled = false;
        Spear.position = DummySpear.position;
        Spear.rotation = DummySpear.rotation;
    }
}
