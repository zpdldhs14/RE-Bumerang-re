using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortag : MonoBehaviour
{
   public GameObject black;
   public float duration = 2f;
   public string sceneName;

   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
            black.SetActive(true);
           UiManager.Instance.FadeAlphaOne(black, duration);
            StartCoroutine(ChangeSceneWithDelay());
        }
   }

    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(sceneName);
    }
}
