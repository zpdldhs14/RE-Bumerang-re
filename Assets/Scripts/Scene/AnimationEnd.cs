using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEnd : MonoBehaviour
{
    public static int isVisited = 0;
    public alphazero1 alpha;
    //public SaveManager saveManager;

    void Start()
    {
        float animationDuration = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Invoke("LoadScene", animationDuration);
    }

    void LoadScene()
    {
        isVisited++;

        //saveManager.SaveGameProgress(isVisited); // 게임 진행도 저장

        switch (isVisited)
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
                SceneManager.LoadScene(5);
                break;
            case 5:
                SceneManager.LoadScene(19);
                break;
            case 6:
                SceneManager.LoadScene(45);
                break;
            case 7:
                SceneManager.LoadScene(22);
                break;
            case 8:
                SceneManager.LoadScene(23);
                break;
            case 9:
                SceneManager.LoadScene(37);
                break;
            case 10:
                SceneManager.LoadScene(15);
                break;
            case 11:
                SceneManager.LoadScene(44);
                break;
            case 12: 
                SceneManager.LoadScene(41);
                break;
            case 13:
                SceneManager.LoadScene(46);
                break;
                
        }
    }
}

