using UnityEngine;
using System.Collections;

public class MainMenuOptions : MonoBehaviour 
{
    private float MusicVolume = 1;
    private bool IsMusicEnabled = false;
    private bool IsWindowShowed = false;

    public AudioSource MusicObject;
    public GUISkin SKIN;
    public Texture ToggleText;
    public Rect OptionsPosition = new Rect(Screen.width - 600, Screen.height - 800, 500, 200);
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        MusicObject.volume = MusicVolume;
        MusicObject.mute = IsMusicEnabled;
	}

    void OnGUI()
    {
        GUI.skin = SKIN;
        if (IsWindowShowed)
        {
            //GUI.Box(new Rect(Screen.width - 600, Screen.height - 800, 500, 200), "");
            OptionsPosition = GUI.Window(0, OptionsPosition, Options, "Options");
        }

        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 150, 100, 50), "Options"))
        {
            if (IsWindowShowed)
            {
                IsWindowShowed = false;
            }
            else
            {
                IsWindowShowed = true;
            }
        }

        GUI.skin = null;
    }

    void Options(int id)
    {
        GUILayout.BeginVertical();

        GUILayout.Label(" ");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Music volume: " + MusicVolume * 100);
        IsMusicEnabled = GUILayout.Toggle(IsMusicEnabled, "Mute");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        MusicVolume = GUILayout.HorizontalSlider(MusicVolume, 0, 1);
        GUILayout.EndHorizontal();

        GUILayout.Label(" ");
        GUILayout.Label(" ");
        GUILayout.Label(" ");
        if (GUILayout.Button("Close"))
        {
            IsWindowShowed = false;
        }

        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
