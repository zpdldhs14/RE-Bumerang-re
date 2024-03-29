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
        if(isVisited == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else if(isVisited == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else if( isVisited == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else if( isVisited == 4)
        {
            StartCoroutine(NextLevel());
        }
    }

     IEnumerator NextLevel()
    {
        alpha.Fadeone();
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(20);
    }
        
}

