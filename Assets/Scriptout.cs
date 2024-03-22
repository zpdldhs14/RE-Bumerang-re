using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Scriptout : MonoBehaviour
{
    public Button yourButton; // 버튼에 대한 참조
    public TMP_Text yourText; // 텍스트에 대한 참조
    public float delay = 2.0f; // 대기 시간
    public GameObject black; // 검은 화면

    void Start()
    {
        yourButton.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        yourButton.interactable = false; // 버튼 비활성화
        yourText.text = "샤워시간에 열쇠를 훔쳐봐야겠다..."; // 텍스트 설정

        // 코루틴 시작
        CoroutineManager.Instance.StartGlobalCoroutine(WaitAndExecute());
    }

    IEnumerator WaitAndExecute()
    {
        // 대기
        yield return new WaitForSeconds(delay);

        // FadeAlphaOne 호출
        UIManager.Instance.FadeAlphaOne(black, 5.0f);

        // 씬 로드
        SceneManager.LoadScene(7);
    }
}