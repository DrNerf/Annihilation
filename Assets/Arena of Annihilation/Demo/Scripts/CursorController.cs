using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour 
{

	public Texture Cursor;
    
    [RangeAttribute(1, 100)]
    public int cursorSize = 16;
 
    void Start()
    {

        Screen.showCursor = false;
    }
 
    void OnGUI()
    {
        GUI.depth = 0;
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, cursorSize, cursorSize), Cursor);
    }
}
