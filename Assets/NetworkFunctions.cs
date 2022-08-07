using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class NetworkFunctions : NetworkBehaviour
{
    [SerializeField]
    TMP_Text msg;
    [ServerRpc]
    public void DisplayMessageServerRpc(string message)
    {
        msg.text = message;
    }
    
}
