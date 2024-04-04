using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class kaidoku : MonoBehaviour
{
    public Button yourButton; // 클릭할 버튼
    public TMP_Text yourText; // 출력할 텍스트

    void Start()
    {
        yourButton.onClick.AddListener(TaskOnClick); // 버튼 클릭 이벤트에 메서드 추가
    }

    void TaskOnClick()
    {
        StartCoroutine(Kaidoku()); // 코루틴 실행
        
    }

    IEnumerator Kaidoku()
    {
        yourText.text = "해독약을 먹었다"; // 텍스트 출력
        yield return new WaitForSeconds(2); // 2초 대기
        yourText.text = "이제 이동해볼까..."; // 텍스트 출력
        yield return new WaitForSeconds(2); // 2초 대기
        yourText.text = ""; // 텍스트 출력
    }
}