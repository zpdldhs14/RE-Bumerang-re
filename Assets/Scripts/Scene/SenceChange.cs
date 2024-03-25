using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SenceChange : MonoBehaviour
{

    public string sceneName;

    void Start()
    {
        StartCoroutine(Sequnence());
    }

    IEnumerator Sequnence()
    {
        UIManager.Instance.FadeAlphaOne(go: this.gameObject, 5.0f);
        yield return new WaitForSeconds(5.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

