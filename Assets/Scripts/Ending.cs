using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Image fadeOutImage; // 페이드 아웃 효과를 위한 이미지
    public string nextScene; // 이동할 다음 씬의 이름
    public alphazero1 alpha;

    void Start()
    {
        StartCoroutine(FadeOutAndSwitchScene());
    }

    IEnumerator FadeOutAndSwitchScene()
    {
        
        alpha.Fadeone();
        yield return new WaitForSeconds(5.0f);
        // 다른 씬으로 전환
        SceneManager.LoadScene(nextScene);

    }
}
