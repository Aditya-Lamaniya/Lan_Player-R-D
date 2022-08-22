using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Tools/Build AssetBundle/Build For Windows")]
    // Start is called before the first frame update
    static void Build_Windows()
    {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
    [MenuItem("Tools/Build AssetBundle/Build For android")]
    static void Build_Android()
    {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
