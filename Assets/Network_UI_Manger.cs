using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;


public class Network_UI_Manger : MonoBehaviour
{
    NetworkManager _networkManager;
    [SerializeField]
    private GameObject startpanel, Serverpanel,ClientMessage;
    [SerializeField]
    NetworkFunctions networkFunctions;
    [SerializeField]
    TMP_Text Clienttxt;
    private void Start()
    {
        _networkManager = NetworkManager.Singleton;
        startpanel.SetActive(true);
        Serverpanel.SetActive(false);
        _networkManager.OnClientConnectedCallback += Clientsuccess;
    }
    void Clientsuccess(ulong dummy)
    {
        Clienttxt.text = "Server is Ready";
    }
    
    public void Onbuttoncall(string Button_Name)
    {
        switch(Button_Name)
        {
            case "Client":
                _networkManager.StartClient();
                startpanel.SetActive(false);
                ClientMessage.SetActive(true);
                Clienttxt.text = "Waiting for Server"; 
                break;

            case "Server":
                _networkManager.StartServer();
                startpanel.SetActive(false);
                Serverpanel.SetActive(true);
                break;
            default:
                Debug.Log("Wrong network call");
                break;
        }        
    }
    
    public void ServerStatus(string Subject)
    {
        networkFunctions.DisplayMessageClientRpc(Subject);
    }
}
