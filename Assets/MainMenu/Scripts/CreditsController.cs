using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour 
{
    private bool ShowCredits = false;

    public Texture QuestionMark;
    public GUISkin Skin;
    public Rect CreditsPosition= new Rect();
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        GUI.skin = Skin;
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 60, 100, 50), "Credits"))
        {
            if (ShowCredits)
            {
                ShowCredits = false;
            }
            else
            {
                ShowCredits = true;
            }
        }

        if (ShowCredits)
        {
            
            //GUILayout.BeginArea(new Rect((Screen.width - Screen.width / 2) - 200, (Screen.height - Screen.height / 2) - 400, 400, 800));
            CreditsPosition = GUI.Window(1, CreditsPosition, DrawCredits, "Credits");
            GUI.skin = null;
        }

    }

    void DrawCredits(int id)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("");
        GUILayout.Label("  Annihilation - Video Game");
        GUILayout.Label("  ");
        GUILayout.Label("  Ivan Ivanov - Project Manager.");
        GUILayout.Label("  Svetoslav Todorov - Developer.");
        GUILayout.Label("  Menu music - Machinimasound.com");
        GUILayout.Label("  Ingame music - RTPN");
        GUILayout.Label("  Blood brushes - Nathradas");
        GUILayout.Label("");
        if (GUILayout.Button("Close"))
        {
            ShowCredits = false;
        }
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
