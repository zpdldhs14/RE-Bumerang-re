using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

/// <summary>
/// 다이얼 퍼즐을 관리하는 클래스입니다.
/// </summary>
public class DialPuzzle : MonoBehaviour
{
    [System.Serializable]
    public class Dial
    {
        public Button button;
        public Text display;
        public int currentValue;
        public int targetValue;
    }

    [Header("퍼즐 설정")]
    [SerializeField] private Dial[] dials;
    [SerializeField] private string targetCode = "921";
    [SerializeField] private float successDelay = 2f;
    
    [Header("퍼즐 오브젝트")]
    [SerializeField] private GameObject closedBox;
    [SerializeField] private GameObject openBox;
    [SerializeField] private Collider2D boxCollider;
    
    [Header("사운드")]
    [SerializeField] private buttonSound buttonSound;

    private void Start()
    {
        // 초기 상태 설정
        SetInitialState();
        InitializeDials();
    }

    private void SetInitialState()
    {
        // 초기에는 모든 상자 비활성화
        if (closedBox != null) closedBox.SetActive(false);
        if (openBox != null) openBox.SetActive(false);
        if (boxCollider != null) boxCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 가방이 콜라이더에 닿으면 닫힌 상자만 활성화
        if (other.CompareTag("Player"))
        {
            if (closedBox != null)
            {
                closedBox.SetActive(true);
                if (openBox != null) openBox.SetActive(false);  // openBox는 확실히 비활성화
                Debug.Log("가방이 닿아서 닫힌 상자 활성화");
            }
        }
    }

    private void InitializeDials()
    {
        if (dials == null || dials.Length == 0)
        {
            Debug.LogError("다이얼이 설정되지 않았습니다!");
            return;
        }

        // 각 다이얼의 초기값 설정
        for (int i = 0; i < dials.Length; i++)
        {
            if (dials[i].button == null || dials[i].display == null)
            {
                Debug.LogError($"다이얼 {i}의 버튼 또는 디스플레이가 설정되지 않았습니다!");
                continue;
            }

            int dialIndex = i; // 클로저를 위한 로컬 변수
            dials[i].button.onClick.AddListener(() => OnDialClicked(dialIndex));
            dials[i].display.text = dials[i].currentValue.ToString();
        }
    }

    private void OnDialClicked(int dialIndex)
    {
        if (dialIndex < 0 || dialIndex >= dials.Length) return;

        // 다이얼 값 증가
        dials[dialIndex].currentValue = (dials[dialIndex].currentValue + 1) % 10;
        dials[dialIndex].display.text = dials[dialIndex].currentValue.ToString();

        // 사운드 재생
        if (buttonSound != null)
        {
            buttonSound.PlayAnimationAndSound();
        }

        // 퍼즐 완료 체크
        CheckPuzzleCompletion();
    }

    private void CheckPuzzleCompletion()
    {
        string currentCode = string.Join("", dials.Select(d => d.currentValue.ToString()));
        if (currentCode == targetCode)
        {
            OnPuzzleComplete();
        }
    }

    private void OnPuzzleComplete()
    {
        StartCoroutine(DisableButtonsForSeconds(successDelay));
    }

    private IEnumerator DisableButtonsForSeconds(float seconds)
    {
        Debug.Log("퍼즐 완료: 버튼 비활성화 시작");
        
        // 모든 버튼을 비활성화합니다.
        foreach (var dial in dials)
        {
            dial.button.interactable = false;
        }

        // 지정된 시간 동안 대기합니다.
        yield return new WaitForSeconds(seconds);

        Debug.Log("퍼즐 완료: 상자 전환 시작");
        
        // 상자 전환
        if (closedBox != null)
        {
            closedBox.SetActive(false);
            Debug.Log("닫힌 상자 비활성화 완료");
        }
        
        if (openBox != null)
        {
            openBox.SetActive(true);
            Debug.Log("열린 상자 활성화 완료");
        }
        
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
            Debug.Log("상자 콜라이더 비활성화 완료");
        }

        // 모든 버튼을 다시 활성화합니다.
        foreach (var dial in dials)
        {
            dial.button.interactable = true;
        }
        Debug.Log("버튼 재활성화 완료");

        GameManager.Instance.Complete202Puzzle();

        // 퍼즐 완료 상태 저장
        SavePuzzleState();
    }

    private void SavePuzzleState()
    {
        PlayerPrefs.SetInt("BoxColliderEnabled", 0);
        PlayerPrefs.Save();
        Debug.Log("퍼즐 완료 상태 저장 완료");
    }

    private void OnDisable()
    {
        SavePuzzleState();
    }
} 