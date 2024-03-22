using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : MonoBehaviour
{
    public static int isVisited = 0;

    void Start()
    {
        float animationDuration = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Invoke("LoadScene", animationDuration);
    }

    void LoadScene()
    {
        isVisited++;
        if(isVisited == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else if(isVisited == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(7);
        }
        
    }
}
