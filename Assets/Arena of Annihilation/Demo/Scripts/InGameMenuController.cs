using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameMenuController : Photon.MonoBehaviour 
{
    public GUISkin Skin;
    public Rect MenuPosition = new Rect(0, 0, 160, 300);

    private Rect OptionsPosition = new Rect(165, 1, 300, 300);
    private bool EscPressed = false;
    private bool OptionsSelected = false;
    private DamageController DmgController;

	// Use this for initialization
	void Start () 
    {
        Screen.lockCursor = true;
        DmgController = GetComponent<DamageController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscPressed)
            {
                EscPressed = false;
                gameObject.GetComponent<MouseLook>().enabled = true;
                Camera.main.GetComponent<MouseLook>().enabled = true;
                Screen.lockCursor = true;
            }
            else
            {
                EscPressed = true;
                gameObject.GetComponent<MouseLook>().enabled = false;
                Camera.main.GetComponent<MouseLook>().enabled = false;
                Screen.lockCursor = false;
            }
        }
	}

    void OnGUI()
    {
        GUI.skin = Skin;
        if (EscPressed)
        {
            MenuPosition = GUI.Window(1, MenuPosition, DrawMenu, "Game Menu");
        }

        if (OptionsSelected)
        {
            OptionsPosition = GUI.Window(3, OptionsPosition, DrawOptions, "Options");
        }
        GUI.skin = null;
    }

    void DrawMenu(int id)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("");

        if (GUILayout.Button("Options"))
        {
            OptionsSelected = true;
        }

        if (GUILayout.Button("Leave"))
        {
            PhotonNetwork.LeaveRoom();
        }

        GUILayout.Label("");

        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
        }

        GUILayout.EndVertical();
        GUI.DragWindow();
    }

    void DrawOptions(int id)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("");

        GUILayout.Label("Interface unlock");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Unlock"))
        {
            GetComponent<MinimapController>().Locked = false;
            GetComponent<DamageController>().IsHealthBarLocked = false;
        }
        if (GUILayout.Button("Lock"))
        {
            GetComponent<MinimapController>().Locked = true;
            GetComponent<DamageController>().IsHealthBarLocked = true;
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("");
        DmgController.BloodEnabled = GUILayout.Toggle(DmgController.BloodEnabled, "Blood Effects");
        GUILayout.Label("");

        if (GUILayout.Button("Close"))
        {
            OptionsSelected = false;
        }

        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
