using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class NetworkFunctions : NetworkBehaviour
{
    [SerializeField]
    TMP_Text msg;
    [ClientRpc]
    public void DisplayMessageClientRpc(string message)
    {
        msg.text = message;
    }
}
