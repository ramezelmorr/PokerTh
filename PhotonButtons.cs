
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;


public class PhotonButtons : MonoBehaviour
{
    public photonHandler pHandler;

    public InputField createRoomInput, joinRoomInput;

    public void onCLickCreateRoom()
    {
        pHandler.createNewRoom();
    }
 

    public void onCLickJoinRoom()
    {

        pHandler.joinOrCreateRoom();

    }
  
     
 

}

     

 


