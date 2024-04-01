using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sence : MonoBehaviour
{
    public GameObject black;
    public float duration = 2f;
    public string sceneName;

    public void ChangeScene()
    {
        StartCoroutine(ChangeSceneWithDelay());
    }

    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(sceneName);
    }
}
