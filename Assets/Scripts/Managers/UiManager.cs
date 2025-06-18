using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// UI 관련 기능을 관리하는 매니저 클래스입니다.
/// </summary>
public class UiManager : Singleton<UiManager>
{
    /// <summary>
    /// 지정된 게임 오브젝트의 이미지를 검은색으로 페이드 인합니다.
    /// </summary>
    /// <param name="go">페이드 효과를 적용할 게임 오브젝트</param>
    /// <param name="duration">페이드 효과 지속 시간</param>
    public void FadeBlack(GameObject go, float duration)
    {
        go.GetComponent<Image>().DOColor(Color.black, duration);
    }

    /// <summary>
    /// 지정된 게임 오브젝트의 이미지를 흰색으로 페이드 인합니다.
    /// </summary>
    /// <param name="go">페이드 효과를 적용할 게임 오브젝트</param>
    /// <param name="duration">페이드 효과 지속 시간</param>
    public void FadeWhite(GameObject go, float duration)
    {
        go.GetComponent<Image>().DOColor(Color.white, duration);
    }

    /// <summary>
    /// 지정된 게임 오브젝트의 이미지 알파값을 1로 페이드 인합니다.
    /// </summary>
    /// <param name="go">페이드 효과를 적용할 게임 오브젝트</param>
    /// <param name="duration">페이드 효과 지속 시간</param>
    public void FadeAlphaOne(GameObject go, float duration)
    {
        Color color = go.GetComponent<Image>().color;
        go.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 1), duration);
    }

    /// <summary>
    /// 지정된 게임 오브젝트의 이미지 알파값을 0으로 페이드 아웃합니다.
    /// </summary>
    /// <param name="go">페이드 효과를 적용할 게임 오브젝트</param>
    /// <param name="duration">페이드 효과 지속 시간</param>
    public void FadeAlphaZero(GameObject go, float duration)
    {
        Color color = go.GetComponent<Image>().color;
        go.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 0), duration);
    }

    /// <summary>
    /// 지정된 게임 오브젝트의 텍스트 알파값을 0으로 페이드 아웃합니다.
    /// </summary>
    /// <param name="go">페이드 효과를 적용할 게임 오브젝트</param>
    /// <param name="duration">페이드 효과 지속 시간</param>
    public void AlphaZeroTxt(GameObject go, float duration)
    {
        Color color = go.GetComponent<Text>().color;
        go.GetComponent<Text>().DOColor(new Color(color.r, color.g, color.b, 0), duration);
    }

    /// <summary>
    /// 지정된 게임 오브젝트의 텍스트 알파값을 1로 페이드 인합니다.
    /// </summary>
    /// <param name="go">페이드 효과를 적용할 게임 오브젝트</param>
    /// <param name="duration">페이드 효과 지속 시간</param>
    public void AlphaOneTxt(GameObject go, float duration)
    {
        Color color = go.GetComponent<Text>().color;
        go.GetComponent<Text>().DOColor(new Color(color.r, color.g, color.b, 1), duration);
    }

    /// <summary>
    /// 지정된 게임 오브젝트의 크기를 1로 스케일링합니다.
    /// </summary>
    /// <param name="go">스케일링할 게임 오브젝트</param>
    /// <param name="duration">스케일링 지속 시간</param>
    public void ScaleOne(GameObject go, float duration)
    {
        RectTransform rect = go.GetComponent<RectTransform>();
        rect.DOScale(1, duration);
    }

    /// <summary>
    /// 지정된 게임 오브젝트의 크기를 0으로 스케일링합니다.
    /// </summary>
    /// <param name="go">스케일링할 게임 오브젝트</param>
    /// <param name="duration">스케일링 지속 시간</param>
    public void ScaleZero(GameObject go, float duration)
    {
        RectTransform rect = go.GetComponent<RectTransform>();
        rect.DOScale(0, duration);
    }

    [Header("메시지 UI")]
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public float messageDisplayTime = 3f;

    public void ShowMessage(string message)
    {
        if (messagePanel != null && messageText != null)
        {
            messagePanel.SetActive(true);
            messageText.text = message;
            StartCoroutine(HideMessageAfterDelay());
        }
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime);
        messagePanel.SetActive(false);
    }

    public void FadeAndLoadScene(GameObject fadeObject, float duration, int sceneIndex)
    {
        StartCoroutine(FadeAndLoadSceneCoroutine(fadeObject, duration, sceneIndex));
    }

    private IEnumerator FadeAndLoadSceneCoroutine(GameObject fadeObject, float duration, int sceneIndex)
    {
        // 페이드 효과 시작
        FadeAlphaOne(fadeObject, duration);
        
        // 페이드 효과가 완료될 때까지 대기
        yield return new WaitForSeconds(duration);
        
        // 씬 전환
        SceneManager.LoadScene(sceneIndex);
    }
}
