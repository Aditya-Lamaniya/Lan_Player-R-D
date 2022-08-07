using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;


public class Network_UI_Manger : MonoBehaviour
{
    NetworkManager _networkManager;
    [SerializeField]
    private GameObject startpanel, Clientpanel,ServerMessage;
    [SerializeField]
    NetworkFunctions networkFunctions;
    [SerializeField]
    TMP_Text servertxt;
    
    private void Start()
    {

        _networkManager = NetworkManager.Singleton;
        startpanel.SetActive(true);
        Clientpanel.SetActive(false);
        _networkManager.OnClientConnectedCallback += clientconnected;
        _networkManager.OnClientDisconnectCallback += clientdisconnected;
        
    }
    
    void clientconnected(ulong dummy)
    {
        servertxt.text = "Client connected ";
    }
    void clientdisconnected(ulong dummy)
    {
        servertxt.text = "Client Disconnected ";
    }
    public void Onbuttoncall(string Button_Name)
    {
        switch(Button_Name)
        {
            case "Server":
                _networkManager.StartServer();
                startpanel.SetActive(false);
                ServerMessage.SetActive(true);
                servertxt.text = "Waiting for client";
                break;

            case "Client":
                _networkManager.StartClient();
                startpanel.SetActive(false);
                Clientpanel.SetActive(true);
                break;
            default:
                Debug.Log("Wrong network call");
                break;
        }        
    }
    
    public void ClientStatus(string Subject)
    {
        if (_networkManager.LocalClient != null)
        {
            // Get `BootstrapPlayer` component from the player's `PlayerObject`
            if (_networkManager.LocalClient.PlayerObject.TryGetComponent(out NetworkFunctions networkFunctions))
            {
                // Invoke a `ServerRpc` from client-side to teleport player to a random position on the server-side
                networkFunctions.DisplayMessageServerRpc(Subject);

            }
        }
    }
}
