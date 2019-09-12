using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class photonHandler : MonoBehaviour {
 
    public PhotonButtons photonB;
    public  static photonHandler instance = null;
    public PhotonView id;
    public Button Player1;
 
    public GameObject cardPrefab;
    private void Awake()
    {


        DontDestroyOnLoad(this.transform);
    }

    public void createNewRoom()
    {
        PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public void joinOrCreateRoom() {


        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);

    }


    public void moveScene()
    {

    PhotonNetwork.LoadLevel("PokerRoom");

    }


    private void OnJoinedRoom()
    {

        moveScene();

        Debug.Log("we are connected to a room !" + PhotonNetwork.PhotonServerSettings.ServerAddress);
        

    }

    



    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)

    {
        if(scene.name == "PokerGame")
        {
           

        }
       

    }


}
 

 