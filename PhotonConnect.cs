using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonConnect : MonoBehaviour
{
    
    
    public string versionName = "0.1";
   public  GameObject sectionView1, sectionView2, sectionView3;


       public void  connectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);

        Debug.Log("Connecting to photon please wait ..");

    }

    private void OnConnectedToMaster() {

        {
            PhotonNetwork.JoinLobby(TypedLobby.Default);
               Debug.Log("we are connected to master");

            if (PhotonNetwork.isMasterClient == true)
            {
              
                ExitGames.Client.Photon.Hashtable newproperties = new ExitGames.Client.Photon.Hashtable();
                PhotonNetwork.room.SetCustomProperties(newproperties);
            }

        }

    }
     
        private void OnJoinedLobby()
    {



        sectionView1.SetActive(false);
        sectionView2.SetActive(true);

            Debug.Log ("On Joined Lobby");

    }

    private void OnDisconnectedFromPhoton()
    {
        if (sectionView1.active)
        
            sectionView1.SetActive(false);



            if (sectionView2.active)

                sectionView2.SetActive(false);


            sectionView3.SetActive(true);





            Debug.Log("disconnected from Photon :(");
        }

    }
