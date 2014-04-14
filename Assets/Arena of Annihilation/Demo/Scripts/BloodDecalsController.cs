using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BloodDecalsController : MonoBehaviour 
{
    public List<DS_DecalProjector> Decals;
    public GameObject Prefab;

    private GameObject ParentDecal;
	// Use this for initialization
	void Start () 
    {
        ParentDecal = GameObject.Find("Decals");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    //void OnGUI()
    //{
    //    if (GUILayout.Button("Instantiate"))
    //    {
    //        GameObject TempBlood = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
    //        TempBlood.transform.parent = ParentDecal.transform;
    //        //ParentDecal.GetComponent<DS_Decals>().UpdateDecalsMeshes();
    //    }
    //}
}
