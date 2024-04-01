using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EveryMemories : MonoBehaviour
{
    public Image image; // 변경할 이미지
    public Sprite[] newSprites; // 새로운 스프라이트 배열
    public float changeInterval = 0.5f; // 이미지 변경 간격
    public string nextScene; // 이동할 다음 씬의 이름
    public FadeBlack black;

    void Start()
    {
        StartCoroutine(ChangeImages());
    }

    IEnumerator ChangeImages()
    {
        foreach (var newSprite in newSprites)
        {
            image.sprite = newSprite;
            yield return new WaitForSeconds(changeInterval);
        }

        StartCoroutine(FadeOutAndSwitchScene());
    }

    IEnumerator FadeOutAndSwitchScene()
    {
        black.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(nextScene);
    }
}