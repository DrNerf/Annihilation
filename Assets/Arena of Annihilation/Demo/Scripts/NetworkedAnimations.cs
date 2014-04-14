using UnityEngine;
using System.Collections;

public class NetworkedAnimations : Photon.MonoBehaviour 
{
    //init
    public Animation Animation;
    public int AnimState;

	// Use this for initialization
	void Start () 
    {
        Animation["walk"].speed = -1;
        Animation["walk"].time = Animation["walk"].length;
        Animation["walk"].wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (photonView.isMine)
        {
            AnimationStateCheck();
        }
        ExecuteAnimation(AnimState);
	}

    //choose what animation to execute
    void AnimationStateCheck()
    {
        if (GetComponent<PickingUpController>().IsPickedUp)
        {
            this.AnimState = 3;
        }
        else
        {
            this.AnimState = 0;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            this.AnimState = 2;
        } 
        if(Input.GetKey(KeyCode.W))
        {
            if (GetComponent<PickingUpController>().IsPickedUp)
            {
                this.AnimState = 4;
            }
            else
            {
                this.AnimState = 1;
            }
            
        }
        if (Input.GetButton("PickUp"))
        {
            this.AnimState = 5;
        }
        if(Input.GetButton("MeleAttack"))
        {
            this.AnimState = 6;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.AnimState = 7;
        }
    }

    //execute the chosen animation
    void ExecuteAnimation(int AnimState)
    {
        switch (AnimState)
        {
            case 1 : Animation.CrossFade("run", (float)0.2); break;
            case 2 : Animation.CrossFade("WalkSide", (float)0.2); break;
            case 3 : Animation.CrossFade("idlebattle", (float)0.2); break;
            case 4 : Animation.CrossFade("charge", (float)0.2); break;
            case 5 : Animation.CrossFade("PickUp", (float)0.2); break;
            case 6 : Animation.CrossFade("attack", (float)0.2); break;
            case 7: 
                {
                    
                    Animation.CrossFade("walk", (float)0.2);
                }; break;
            default : Animation.CrossFade("idle", (float)0.2); break;
        }
    }

}
