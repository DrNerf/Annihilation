using UnityEngine;
using System.Collections;

public class MeleAttackController : Photon.MonoBehaviour 
{

    public bool IsAttacking = false;
    public bool Cooldown = false;

    private BoxCollider AttackCollider;

	// Use this for initialization
	void Start () 
    {
        AttackCollider = GetComponent<BoxCollider>();
        AttackCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if we press left mouse button submit attack and lock cooldown
        if (Input.GetButton("MeleAttack"))
        {
            if (!Cooldown)
            {
                if (photonView.isMine)
                {
                    IsAttacking = true;
                    Invoke("SetOnCooldown", 0.1f);
                }
            }
        }//if we dont press left mouse button we ensure that we dont attack
        else
        {
            if (photonView.isMine)
            {
                IsAttacking = false;
            }
        }
        //if we are attacking enable the object that will tell players that we attack
        if (IsAttacking)
        {
            AttackCollider.enabled = true;
        }//if not disable that object
        else
        {
            AttackCollider.enabled = false;
        }
	}

    //we submited an attack now its time to disable it for a 1.2 seconds
    void SetOnCooldown()
    {
        this.Cooldown = true;
        IsAttacking = false;
        Invoke("ReleaseOfCooldown", 1.2f);
    }

    //1.2 seconds have passed now its time to release the player of that cooldown
    void ReleaseOfCooldown()
    {
        this.Cooldown = false;
    }
}
