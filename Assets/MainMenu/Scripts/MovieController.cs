using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]
public class MovieController : MonoBehaviour 
{
    public MovieTexture Movie;

    private float MovieTimer;
    private bool DrawMovie = true;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        MovieTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape) || MovieTimer > Movie.duration)
        {
            Movie.Stop();
            DrawMovie = false;
        }
	}

    void OnGUI()
    {
        if (DrawMovie)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Movie);
            Movie.Play();
        }
    }
}
