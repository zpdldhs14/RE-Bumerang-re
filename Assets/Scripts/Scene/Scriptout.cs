using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class Scriptout : MonoBehaviour
{
    public Button yourButton; // 버튼에 대한 참조
    public TMP_Text yourText; // 텍스트에 대한 참조
    public float delay = 5.0f; // 대기 시간
    public GameObject black; // 검은 화면
    public GameObject trigger; // 트리거
    public string SceneName;
    [SerializeField]private string m_text;
    private bool isVisited = false;

    void Start()
    {
        yourButton.onClick.AddListener(ButtonClicked);
        if (!isVisited)
        {
            trigger.SetActive(true);
            isVisited = true;
        }
        else
        {
            trigger.SetActive(false);
        }
    }

    void ButtonClicked()
    {
        yourButton.gameObject.SetActive(false); // 버튼 오브젝트 비활성화
        StartCoroutine(HideText()); // 코루틴 실행
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Sequnence());
        }
    }

    IEnumerator Sequnence()
    {
        black.SetActive(true);
        UiManager.Instance.FadeAlphaOne(black, delay);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator HideText()
    {
        // 버튼 오브젝트가 비활성화될 때까지 대기
        while (yourButton.gameObject.activeInHierarchy)
        {
            yield return null;
        }

        for(int i = 0; i <= m_text.Length; i++)
        {
            //substring(start index, length)
            yourText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3.0f); // 대기
        yourText.text = ""; // 텍스트 숨기기
    }
}