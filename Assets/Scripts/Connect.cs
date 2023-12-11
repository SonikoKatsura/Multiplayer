using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    override
    public void OnConnectedToMaster()
    {
        print("conectado al master");
    }
    public void ButonConnect()
    { 
        RoomOptions options = new RoomOptions() { MaxPlayers=4 };
        PhotonNetwork.JoinOrCreateRoom("room1" ,options, TypedLobby.Default);
    }
    override
    public void OnJoinedRoom()
    {
        Debug.Log("Conectado a la sala " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Hay " + PhotonNetwork.CurrentRoom.PlayerCount + " Jugadores");
    }
    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            PhotonNetwork.LoadLevel(1);
            Destroy(this);    
        }
    }
}
