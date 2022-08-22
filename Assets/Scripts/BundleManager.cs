using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class BundleManager : MonoBehaviour
{
    public void BundleLoader(string Bundlename)
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, Bundlename));
        var bundlescenes = myLoadedAssetBundle.GetAllScenePaths();
        foreach(var i in bundlescenes)
        {
            Debug.Log(i);
        }
    }
}
