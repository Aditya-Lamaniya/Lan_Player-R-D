using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class NetworkFunctions : NetworkBehaviour
{
    string[] bundlescenes;
    [SerializeField]
    TMP_Text msg;
    [ClientRpc]
    public void DisplayMessageClientRpc(string message)
    {
        msg.text = message;
    }
    [ClientRpc]
    
    public void BundleLoaderClientRpc(string Bundlename)
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, Bundlename));
        bundlescenes = myLoadedAssetBundle.GetAllScenePaths();
        msg.text = " ";
        foreach (var i in bundlescenes)
        {
            msg.text = msg.text+Path.GetFileNameWithoutExtension(i)+ " , ";
        }
    }
    [ClientRpc]
    public void SceneloaderClientRpc(string scenename)
    {
        SceneManager.LoadScene(scenename);
        
    }

}
