using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Animate6th : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        float animationDuration = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Invoke("LoadScene", animationDuration);
    }

    // Update is called once per frame
    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
