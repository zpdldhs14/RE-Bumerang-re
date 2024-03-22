using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Changed : MonoBehaviour
{
    public Image fadeimage;
    public float duration = 2f;
    void Start()
    {
        fadeimage.color = new Color(0, 0, 0, 0);
    }

    public void ChangeScene()
    {
        StartCoroutine(ChangeSceneWithDelay());
    }

    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(1);
    }
    
    private IEnumerator Fadeout()
    {
        for(float t = 0.00f; t< duration; t += Time.deltaTime)
        {
            fadeimage.color = new Color(0, 0, 0, t / duration);
            yield return null;
        }
    }


}
