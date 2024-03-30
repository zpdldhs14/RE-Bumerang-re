using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimationEnd : MonoBehaviour
{
    public static int isVisited = 0;
    public alphazero1 alpha;

    void Start()
    {
        float animationDuration = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Invoke("LoadScene", animationDuration);
    }

    void LoadScene()
    {
        isVisited++;
        switch(isVisited)
        {
            case 1:
                SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(7);
                break;
            case 4:
                SceneManager.LoadScene(2);
                break;
            case 5:
                SceneManager.LoadScene(19);
                break;
            case 6:
                SceneManager.LoadScene(2);
                break;
            case 7:
                SceneManager.LoadScene(22);
                break;
            case 8:
            case 9:
            case 10:
            case 11:
            case 12: 
                SceneManager.LoadScene(2);
                break;
                
        }
    }
}

