using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class bal : MonoBehaviourPunCallbacks
{
    public TMP_Text greenTeamText;

    public TMP_Text purpleTeamText;
    public int teamGreenScore = 0;

    public int teamPurpleScore = 0;

    Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void UpdateScoreText()
    {
        teamGreenScore = (int)PhotonNetwork.CurrentRoom.CustomProperties["cortextwo"];
        teamPurpleScore = (int)PhotonNetwork.CurrentRoom.CustomProperties["cortexone"];

        greenTeamText.text = "Team Green:" + teamGreenScore;
        purpleTeamText.text = "Team Purple:" + teamPurpleScore;
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 startPoint = new Vector3(0, 1, 0);

        if(other.tag == "green")
        {
            teamPurpleScore += 1;
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable(){{"cortexone",teamPurpleScore}});
        }


        if(other.tag == "purple")
        {
            teamGreenScore += 1;
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable(){{"cortextwo",teamGreenScore}});
        }
        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
