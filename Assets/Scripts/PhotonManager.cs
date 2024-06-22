using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public GameObject LobbyPanal;
    public GameObject LoadingPanal;
    public TMP_InputField RoomName;
    public TMP_InputField joinRoomName;
    // Start is called before the first frame update
    void Start()
    {
        LobbyPanal.SetActive(false);
        LoadingPanal.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
    }

    #region CallBacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        
    }

    public override void OnJoinedLobby()
    {
        print("Joined to lobby");
        LoadingPanal.SetActive(false);
        LobbyPanal.SetActive(true);
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(RoomName.text, new Photon.Realtime.RoomOptions { MaxPlayers =4 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        PhotonNetwork.LoadLevel("Gameplay");

    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("Player joined room");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");
    }
    #endregion

}
