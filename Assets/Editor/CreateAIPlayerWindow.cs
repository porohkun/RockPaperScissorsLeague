
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class CreateAIPlayerWindow : EditorWindow
{
    private string _assetName = "";

    [MenuItem("Tools/Create AI Player")]
    public static void Init()
    {
        var window = Editor.CreateInstance<CreateAIPlayerWindow>();
        window.position = new Rect(0, 0, 200, 100);
        window.titleContent = new GUIContent() { text = "AI Player Creation" };
        window.Show();
    }

    public void OnGUI()
    {
        DrawCreateItem();
    }

    void DrawCreateItem()
    {
        GUILayout.Space(10);
        _assetName = EditorGUILayout.TextField("Model name:", _assetName);
        GUILayout.Space(30);
        if (GUILayout.Button("Create AI Player"))
        {
            var result = CreateScriptableObject<AIPlayerModel>(AIPlayerModel.AssetsFolder, _assetName);
            if (result != null)
            {
                Selection.activeObject = result;
            }
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Create Fair Play AI Strategy"))
        {
            var result = CreateScriptableObject<FairPlayStrategy>(AIStrategy.AssetsFolder, _assetName);
            if (result)
            {
                Selection.activeObject = result;
            }
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Create Cheater AI Strategy"))
        {
            var result = CreateScriptableObject<CheaterStrategy>(AIStrategy.AssetsFolder, _assetName);
            if (result)
            {
                Selection.activeObject = result;
            }
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Create Revenge AI Strategy"))
        {
            var result = CreateScriptableObject<RevengeStrategy>(AIStrategy.AssetsFolder, _assetName);
            if (result)
            {
                Selection.activeObject = result;
            }
        }
        GUILayout.Space(20);
        if (GUILayout.Button("Create Geralt AI Strategy"))
        {
            var result = CreateScriptableObject<GeraltStrategy>(AIStrategy.AssetsFolder, _assetName);
            if (result)
            {
                Selection.activeObject = result;
            }
        }
    }

    T CreateScriptableObject<T>(string path, string name) where T : ScriptableObject
    {
        var asset = CreateInstance<T>();
        var assetPath = AssetDatabase.GenerateUniqueAssetPath(string.Format("{0}/{1}.asset", path, name));
        Debug.Log("New asset path: " + assetPath);
        AssetDatabase.CreateAsset(asset, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        return asset;
    }
}