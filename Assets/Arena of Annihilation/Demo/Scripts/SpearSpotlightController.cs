using UnityEngine;
using System.Collections;

public class SpearSpotlightController : MonoBehaviour 
{
    public GameObject SpearSpotlight;
	// Update is called once per frame
    void Start()
    {
    }
	void Update () 
    {
	    if(transform.parent != null)
        {
            SpearSpotlight.SetActive(false);
        }
        else
        {
            SpearSpotlight.SetActive(true);
        }
	}
}
