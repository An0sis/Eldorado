using Photon.Pun;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if(PhotonNetwork.IsConnected && PhotonNetwork.InLobby)
            PhotonNetwork.JoinRoom("Master");
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
}
