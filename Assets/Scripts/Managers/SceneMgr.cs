using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

    }

    public void GoMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoStage(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadSceneAdditive(int index)
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

}
