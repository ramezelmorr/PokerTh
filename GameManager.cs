using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject PlayerInfoText;
    [SerializeField] private GameObject PlayerGrid;

    // called by photon
    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {

        GameObject obj = Instantiate(PlayerInfoText, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(PlayerGrid.transform, false);
        obj.GetComponent<Text>().text = player.name + "a new player has Joined the server";
        obj.GetComponent<Text>().color = Color.green;
        Debug.Log("Player has Joined");
    }
     
            public  void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {

        GameObject obj = Instantiate(PlayerInfoText, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(PlayerGrid.transform, false);
        obj.GetComponent<Text>().text = player.name + "a player has Left the server";
        obj.GetComponent<Text>().color = Color.green;
        Debug.Log("Player has left");
    }






	}

