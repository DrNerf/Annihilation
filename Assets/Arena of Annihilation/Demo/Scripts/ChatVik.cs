using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// This simple chat example showcases the use of RPC targets and targetting certain players via RPCs.
/// </summary>
public class ChatVik : Photon.MonoBehaviour
{

    public static ChatVik SP;
    public List<string> messages = new List<string>();
    public List<GameObject> Walls = new List<GameObject>();

    private int chatHeight = (int)160;
    private string chatInput = "";
    private float lastUnfocusTime = 0;
    private float TempTime = 600;
    private bool IsCageFullyDestroyed = false;


    void Awake()
    {
        SP = this;
    }

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            this.messages.Add(" ");
        }
    }

    void Update()
    {
    }

    void OnGUI()
    {        
        GUI.SetNextControlName("");

        GUILayout.BeginArea(new Rect(0, Screen.height - chatHeight, Screen.width, chatHeight));
        
        //Show scroll list of chat messages
        GUILayout.BeginVertical();
        GUI.color = Color.red;
        foreach (string item in messages)
        {
            GUILayout.Label(item);
        }
        GUILayout.EndVertical();
        GUI.color = Color.white;

        //Chat input
        GUILayout.BeginHorizontal(); 
        GUI.SetNextControlName("ChatField");
    chatInput = GUILayout.TextField(chatInput, GUILayout.MinWidth(200));
       
        if (Event.current.type == EventType.keyDown && Event.current.character == '\n'){
            if (GUI.GetNameOfFocusedControl() == "ChatField")
            {                
                SendChat(PhotonTargets.All);
                lastUnfocusTime = Time.time;
                GUI.FocusControl("");
                GUI.UnfocusWindow();
            }
            else
            {
                if (lastUnfocusTime < Time.time - 0.1f)
                {
                    GUI.FocusControl("ChatField");
                }
            }
        }

        //if (GUILayout.Button("SEND", GUILayout.Height(17)))
         //   SendChat(PhotonTargets.All);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

    

        GUILayout.EndArea();
    }

    public static void AddMessage(string text)
    {
        SP.messages.Add(text);
        if (SP.messages.Count > 5)
            SP.messages.RemoveAt(0);
    }


    [RPC]
    void SendChatMessage(string text, PhotonMessageInfo info)
    {
        if (text == "/ready")
        {
            DestroyCage();
        }
        AddMessage("[" + info.sender + "] " + text);
    }

    void SendChat(PhotonTargets target)
    {
        if (chatInput != "")
        {
            photonView.RPC("SendChatMessage", target, chatInput);
            chatInput = "";
        }
    }

    void SendChat(PhotonPlayer target)
    {
        if (chatInput != "")
        {
            chatInput = "[PM] " + chatInput;
            photonView.RPC("SendChatMessage", target, chatInput);
            chatInput = "";
        }
    }

    void OnLeftRoom()
    {
        this.enabled = false;
    }

    void OnJoinedRoom()
    {
        this.enabled = true;
    }
    void OnCreatedRoom()
    {
        this.enabled = true;
    }
    
    //First Stage of Destroyment of the cage
    void DestroyCage()
    {
        iTween.MoveTo(GameObject.Find("Cages"), new Vector3(23.03421f, 10f, 45.92979f), 6);
        //Destroy(GameObject.Find("Cages"));
        
    }


}
