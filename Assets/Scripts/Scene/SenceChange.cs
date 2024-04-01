using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SenceChange : MonoBehaviour
{
    public alphazero1 alpha;

    public string sceneName;

    void Start()
    {
        StartCoroutine(Sequnence());
    }

    IEnumerator Sequnence()
    {
        alpha.Fadeone();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName);
    }
}

