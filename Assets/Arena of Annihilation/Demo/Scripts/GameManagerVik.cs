using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerVik : Photon.MonoBehaviour {

    // this is a object name (must be in any Resources folder) of the prefab to spawn as player avatar.
    // read the documentation for info how to spawn dynamically loaded game objects at runtime (not using Resources folders)
    public string playerPrefabName = "Charprefab2";
    public List<Transform> SpawnPoints;
    public Transform CameraLockPoint;

    void OnJoinedRoom()
    {
        StartGame();
        //Camera.main.audio.Play();
    }
    
    IEnumerator OnLeftRoom()
    {
        //Easy way to reset the level: Otherwise we'd manually reset the camera

        //Wait untill Photon is properly disconnected (empty room, and connected back to main server)
        while(PhotonNetwork.room!=null || PhotonNetwork.connected==false)
            yield return 0;

        Application.LoadLevel(Application.loadedLevel);

    }

    void StartGame()
    {
        Camera.main.farClipPlane = 1000; //Main menu set this to 0.4 for a nicer BG    

        //prepare instantiation data for the viking: Randomly diable the axe and/or shield
        //bool[] enabledRenderers = new bool[2];
        //enabledRenderers[0] = Random.Range(0,2)==0;//Axe
        //enabledRenderers[1] = Random.Range(0, 2) == 0; ;//Shield
        
        //object[] objs = new object[1]; // Put our bool data in an object array, to send
        //objs[0] = enabledRenderers;

        // Spawn our local player
        Transform SpawnPointTemp = SpawnPoints[Random.Range(0, 6)];
        GameObject player = PhotonNetwork.Instantiate("Charprefab2", SpawnPointTemp.position, SpawnPointTemp.rotation, 0);
        SetLayerRecursively(player, 9);
        player.GetComponent<MouseLook>().enabled = true;
        Camera.main.gameObject.GetComponent<MouseLook>().enabled = true;
        player.AddComponent("Rigidbody");
        player.AddComponent("RigidBodyCharController");
        player.rigidbody.mass = 10;
        player.GetComponent<FirstPersonInitialize>().enabled = true;
        

    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {

        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }

    }


    void OnGUI()
    {
        if (PhotonNetwork.room == null) return; //Only display this GUI when inside a room

        //if (GUILayout.Button("Leave& QUIT"))
        //{
        //    PhotonNetwork.LeaveRoom();
        //}
    }


    void OnDisconnectedFromPhoton()
    {
        Debug.LogWarning("OnDisconnectedFromPhoton");
    }
    void OnFailedToConnectToPhoton()
    {
        Debug.LogWarning("OnFailedToConnectToPhoton");
    }
  
}
