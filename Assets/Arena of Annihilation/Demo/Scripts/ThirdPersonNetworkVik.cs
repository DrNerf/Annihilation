using UnityEngine;
using System.Collections;

public class ThirdPersonNetworkVik : Photon.MonoBehaviour
{
    ThirdPersonCameraNET cameraScript;
    ThirdPersonControllerNET controllerScript;

    public Animation Animation;
    public GameObject MeleAttackTrigger;

    private string Key;
    private string CorrectKey;

    void Awake()
    {
        cameraScript = GetComponent<ThirdPersonCameraNET>();
        controllerScript = GetComponent<ThirdPersonControllerNET>();

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //We own this player: send the others our data
           // stream.SendNext((int)controllerScript._characterState);
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            //stream.SendNext(rigidbody.velocity);
            NetworkedAnimations Na = GetComponent<NetworkedAnimations>();
            stream.SendNext(Na.AnimState);
            PickingUpController PC = GetComponent<PickingUpController>();
            stream.SendNext(PC.IsPickedUp);
            MeleAttackController MT = MeleAttackTrigger.GetComponent<MeleAttackController>();
            stream.SendNext(MT.IsAttacking);
            stream.SendNext(MT.Cooldown);

        }
        else
        {
            //Network player, receive data
            //controllerScript._characterState = (CharacterState)(int)stream.ReceiveNext();
            correctPlayerPos = (Vector3)stream.ReceiveNext();
            correctPlayerRot = (Quaternion)stream.ReceiveNext();
            //rigidbody.velocity = (Vector3)stream.ReceiveNext();
            NetworkedAnimations Na = GetComponent<NetworkedAnimations>();
            Na.AnimState = (int)stream.ReceiveNext();
            PickingUpController PC = GetComponent<PickingUpController>();
            PC.IsPickedUp = (bool)stream.ReceiveNext();
            MeleAttackController MT = MeleAttackTrigger.GetComponent<MeleAttackController>();
            MT.IsAttacking = (bool)stream.ReceiveNext();
            MT.Cooldown = (bool)stream.ReceiveNext();
            
        }
    }

    private Vector3 correctPlayerPos = Vector3.zero; //We lerp towards this
    private Quaternion correctPlayerRot = Quaternion.identity; //We lerp towards this

    void Update()
    {
        //move other players
        if (!photonView.isMine)
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, correctPlayerRot, Time.deltaTime * 5);
            
        }
    }

    

}