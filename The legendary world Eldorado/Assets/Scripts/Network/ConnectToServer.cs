using Photon.Pun;
using UnityEngine;

public class ConnectToServer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }
}
