using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;
using UnityEngine.SceneManagement;
using System;

public class GlitchCut : MonoBehaviour
{
    public DigitalGlitch glitch;
    public alphazero1 alpha;
    public float intensity;
    public float duration;
    public bool Intensity = false;
    public string sceneName;

    void Update()
    {
        if (Intensity)
        {
            intensity += Time.deltaTime * duration;
            intensity = Mathf.Clamp(intensity, 0, 0.7f);
            glitch.intensity = intensity;
        }
    }

    void Start()
    {
        Intensity = true;
        StartCoroutine(Sequnence());
    }

    IEnumerator Sequnence()
    {
        yield return new WaitForSeconds(4.0f);
        alpha.Fadeone();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName);
    }

}
