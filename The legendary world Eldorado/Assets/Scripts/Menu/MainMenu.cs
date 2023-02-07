using Photon.Pun;
using PlayFab;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI status;
    public void PlayGame()
    {
        if (PlayFabClientAPI.IsClientLoggedIn())
            if (PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.JoinRoom("Master");
                status.text = "Status : Loading...";

            }
            else
                PlayGame();
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom("Master");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        SceneManager.LoadScene("MainMenu");
    }
    public override void OnJoinedRoom() 
    {
        PhotonNetwork.LoadLevel("Level 1");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
