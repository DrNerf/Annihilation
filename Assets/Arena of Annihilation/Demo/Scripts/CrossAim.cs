using UnityEngine;
using System.Collections;

public class CrossAim : MonoBehaviour 
{
    public Texture Picture;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width / 2) + 10, (Screen.height / 2) - 20, 40, 40), Picture);
    }
}
