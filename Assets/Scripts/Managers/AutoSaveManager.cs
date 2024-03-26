using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AutoSaveManager : MonoBehaviour
{

    public static void Save()
    {
        SaveGame();
    }

    private static void SaveGame()
    {
        Debug.Log("Auto-saving...");
        EditorApplication.SaveScene();
        AssetDatabase.SaveAssets();
        Debug.Log("Auto-save completed.");
    }
}