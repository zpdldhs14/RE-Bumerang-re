using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalktoLaste : MonoBehaviour
{
    public GameObject dialogObject; // 활성화할 대화 오브젝트
    public TMP_Text dialogText; // 대화 텍스트

    // 플레이어와의 충돌을 감지
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 대화 오브젝트를 활성화
            dialogObject.SetActive(true);

            // 대화 스크립트를 실행
            StartCoroutine(DialogScript());
        }
    }

    // 대화 스크립트
    IEnumerator DialogScript()
    {
        string[] dialogues = { 
        "비토 : 나 다 기억나버렸어. 그치만 이건 나에게 너무 끔찍해. 차라리 기억을 지워줘... 너무 괴롭단 말이야...",
        "라스테 : 허... 역시 그럴줄 알았어. 기다려봐. 연구원을 불러줄게.",
        "", // 3초 정적
        "라프 : 라스테 무슨일이야?",
        "라스테 : 이녀석, 기억을 또 지워달라고 하네. 너가 실험실로 데려가서 기억을 지워줘.",
        "라프 : 또? 하.... 귀찮은 일은 죄다 나한테 맡기지... 알았어. 거기 꼬맹이. 날 따라서 실험실로 와. 지하에 있어."
        };

        foreach (var dialogue in dialogues)
        {
            ShowText(dialogue);
            yield return new WaitForSeconds(3f);
        }

        dialogObject.SetActive(false);
    }

    public void ShowText(string text)
    {
        dialogText.text = text;
    }
}