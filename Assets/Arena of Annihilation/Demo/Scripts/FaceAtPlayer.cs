using UnityEngine;
using System.Collections;

public class FaceAtPlayer : MonoBehaviour 
{

    public Transform Target;
    public Transform DamageBegin;
    public Transform DamageEnd;
    public Transform DamageText;

    private Vector3 EndPoint;

    void Start()
    {
        EndPoint = DamageEnd.position;
        Target = Camera.main.transform;
        
    }
	
	// Update is called once per frame
	void Update () 
    {
        //if we have camera make the text face it
        if (Target != null)
        {
            transform.LookAt(Target);
        }

        DamageText.position = Vector3.Lerp(DamageText.position, EndPoint, Time.deltaTime * 4);
        //Invoke("DestroyIt", 1);
	}

    void DestroyIt()
    {
            Destroy(gameObject);
    }
}
