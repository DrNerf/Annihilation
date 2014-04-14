using UnityEngine;
using System.Collections;

public class ButtonsController : MonoBehaviour 
{
    public Transform Default;
    public Transform Hover;
    public string MethodName;
    public AnimationCurve FragmentingCurve;

    private Material FragmentMat;
    private float Delta;
    private bool IsHovering = false;
    private bool IsFragmenting = false;
	// Use this for initialization
	void Start () 
    {
        FragmentMat = GetComponent<Fragmentum>().GetMaterial();
        Delta = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Default.position, Time.deltaTime * 2);

        if (IsHovering)
        {
            transform.position = Vector3.Lerp(transform.position, Hover.position, Time.deltaTime * 2);
        }

        if (IsFragmenting)
        {
            Delta += Time.deltaTime;
            FragmentMat.SetFloat("_FragTexStrength", FragmentingCurve.Evaluate(Delta));
        }
    }

    void OnMouseEnter()
    {
        IsHovering = true;
    }

    void OnMouseExit()
    {
        IsHovering = false;
    }

    void OnMouseDown()
    {
        IsFragmenting = true;
        Invoke(MethodName, 2);
    }

    void ExitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    void Multiplayer()
    {
        //CameraController Temp = Camera.main.GetComponent<CameraController>();
        //Temp.LerpingObject = MultiplayerLerpTarget;
        //Temp.DefaultPosition = MultiplayerLerpTarget;
        //Temp.TargetLerp = MultiplayerLerpTarget;
        //Invoke("LoadMultiplayer", 5);
    }

    void LoadMultiplayer()
    {
        Application.LoadLevel(1);
    }

    void Training()
    {
        Application.LoadLevel(2);
    }
}
