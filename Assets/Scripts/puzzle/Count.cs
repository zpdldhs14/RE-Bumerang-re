using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public buttonSound buttonSound;
    public Button button1; // 첫 번째 버튼
    public Button button2; // 두 번째 버튼
    public Button button3; // 세 번째 버튼
    public Text text1; // 첫 번째 텍스트
    public Text text2; // 두 번째 텍스트
    public Text text3; // 세 번째 텍스트
    public GameObject box;
    public GameObject boxopen;
    public Collider2D boxCollider; // 가방 오브젝트의 콜라이더


    private int currentNumber1 = 0; // 첫 번째 텍스트의 현재 숫자
    private int currentNumber2 = 0; // 두 번째 텍스트의 현재 숫자
    private int currentNumber3 = 0; // 세 번째 텍스트의 현재 숫자
    private string puzzleKey = "921"; // 퍼즐의 고유한 키

    private Dictionary<string, bool> puzzleCompletionStatus; // 퍼즐 완료 상태 딕셔너리

    void Start()
    {
        // 퍼즐 완료 상태 딕셔너리 초기화
        puzzleCompletionStatus = new Dictionary<string, bool>();

        // 각 버튼의 클릭 이벤트에 숫자 변경 메서드를 추가합니다.
        button1.onClick.AddListener(() => ChangeNumber(text1, ref currentNumber1));
        button2.onClick.AddListener(() => ChangeNumber(text2, ref currentNumber2));
        button3.onClick.AddListener(() => ChangeNumber(text3, ref currentNumber3));
        
        if (PlayerPrefs.GetInt("BoxColliderEnabled", 1) == 0)
        {
            boxCollider.enabled = false;
        }
    }

    void OnDisable()
    {
        // 스크립트가 비활성화될 때 boxCollider의 활성 상태를 PlayerPrefs에 저장합니다.
        PlayerPrefs.SetInt("BoxColliderEnabled", boxCollider.enabled ? 1 : 0);
    }
    
    void Update()
    {
        // 퍼즐이 완료되면 가방 오브젝트의 콜라이더를 비활성화하고 상태를 저장합니다.
        if (text1.text + text2.text + text3.text == puzzleKey)
        {
            boxCollider.enabled = false;
            PlayerPrefs.SetInt("BoxColliderEnabled", 0);
            Debug.Log("퍼즐 완료");
        }
    }

    void ChangeNumber(Text text, ref int currentNumber)
    {
        // 텍스트의 숫자를 변경합니다.
        text.text = currentNumber.ToString();

        // 숫자를 증가시키거나 0으로 초기화합니다.
        if (currentNumber < 9)
        {
            currentNumber++;
        }
        else
        {
            currentNumber = 0;
        }

        // 모든 텍스트의 값이 '921'인지 확인하고, 그에 따라 버튼의 클릭 가능 여부를 설정합니다.
        if (text1.text == "9" && text2.text == "2" && text3.text == "1")
        {
            
            StartCoroutine(DisableButtonsForSeconds(2f));
        }
    }

        void SetPuzzleCompletionStatus(string key, bool isCompleted)
    {
        // 퍼즐 완료 상태 딕셔너리에 퍼즐의 고유한 키와 완료 여부를 설정합니다.
        if (!puzzleCompletionStatus.ContainsKey("921"))
        {
            puzzleCompletionStatus.Add("921", isCompleted);
        }
        else
        {
            puzzleCompletionStatus["921"] = isCompleted;
        }
    }

    IEnumerator DisableButtonsForSeconds(float seconds)
    {
        // 모든 버튼을 비활성화합니다.
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;

        // 지정된 시간 동안 대기합니다.
        yield return new WaitForSeconds(seconds);
        box.SetActive(false);
        boxopen.SetActive(true);

        // 모든 버튼을 다시 활성화합니다.
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
    }
}