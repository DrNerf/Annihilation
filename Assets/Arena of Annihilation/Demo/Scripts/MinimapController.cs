using UnityEngine;
using System.Collections;

public class MinimapController : MonoBehaviour 
{
    public Rect MinimapPosition = new Rect();
    public GUIStyle Style;
    public GameObject MinimapPrefab;
    public Transform MinimapCameraPosition;
    public bool Locked = true;

    private GameObject Minimap;
    private Camera CameraComponent;
    void OnGUI()
    {
        
        MinimapPosition = GUI.Window(2, MinimapPosition, DrawMinimap, "Minimap", Style);
        CameraComponent.pixelRect = new Rect(MinimapPosition.x, Screen.height - MinimapPosition.y - 200, 200, 200) ;
    }

    void DrawMinimap(int id)
    {
        if (!Locked)
        {
            GUI.DragWindow();
        }
    }

    void Start()
    {
        Minimap = Instantiate(MinimapPrefab, MinimapCameraPosition.position, MinimapCameraPosition.rotation) as GameObject;
        Minimap.transform.parent = MinimapCameraPosition;
        CameraComponent = Minimap.GetComponent<Camera>();

        MinimapPosition = new Rect(Screen.width - 200, 0, 200, 200);
    }
}
