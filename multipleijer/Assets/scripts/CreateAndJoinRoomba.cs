using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRoomba : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;

    public TMP_InputField joinInput;
    // Start is called before the first frame update
    public void CreateRoom()
    {
        RoomOptions roomOptions= new RoomOptions();
        ExitGames.Client.Photon.Hashtable roomCustomProps = new ExitGames.Client.Photon.Hashtable();
        roomCustomProps.Add("cortexone",0);
        roomCustomProps.Add("cortextwo",0);
        roomOptions.CustomRoomProperties=roomCustomProps;
        //new room go brrrrr
        PhotonNetwork.CreateRoom(createInput.text,roomOptions);

        
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