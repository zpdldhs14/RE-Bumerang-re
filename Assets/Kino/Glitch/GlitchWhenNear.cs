using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;
using UnityEngine.SceneManagement;



public class GlitchWhenNear : MonoBehaviour
{
    public DigitalGlitch glitch;
    public AnalogGlitch analogGlitch;
    public float intensity;
    public float duration;
    public bool  Intensity = false;
    public ClickManager clickManager;
    public Animator anim;
    public alphazero1 alpha;
    public string sceneName;
    public GameObject trigger;
    public static bool isVisited;

    void Update()
    {
        if(Intensity)
        {
            intensity += Time.deltaTime * duration;
            intensity = Mathf.Clamp(intensity, 0, 0.7f);
            glitch.intensity = intensity;
            analogGlitch.scanLineJitter = intensity;
        }
    }


    void Start()
    {
        if(!isVisited)
        {
            trigger.SetActive(true);
            isVisited = true;
        }
        else
        {
            trigger.SetActive(false);
        }
    }

    void OnDisable()
    {
        isVisited = true;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Intensity = true;
            StartCoroutine(Sequnence());
            //SceneManager.LoadScene(sceneName);

        }
    }

    IEnumerator Sequnence()
    {
        if (clickManager != null)
        {
            clickManager.enabled = false;
            anim.SetBool("isWalk", false);
            alpha.Fadeone();
        }
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Intensity = false;
        }
    }

 
}
