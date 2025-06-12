using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRoom : MonoBehaviour
{
    public GameObject black;
    public float duration = 2f;
    public string sceneName;
    public Collider2D collider;

    public bool isVisited = false;
    

    void Start()
    {
        if (isVisited == true)
        {
            collider.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isVisited = true;
            black.SetActive(true);
            UiManager.Instance.FadeAlphaOne(black, duration);
            StartCoroutine(ChangeSceneWithDelay());
        }
    }

    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(duration);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
