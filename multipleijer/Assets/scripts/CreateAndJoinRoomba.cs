using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class CreateAndJoinRoomba : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;

    public TMP_InputField joinInput;
    // Start is called before the first frame update
    public void CreateRoom()
    {
        //new room go brrrrr
        PhotonNetwork.CreateRoom(createInput.text);

        
    }


    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);


    }



    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("peli");


    }


}