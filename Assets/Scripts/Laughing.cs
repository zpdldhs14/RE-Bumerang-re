using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class Laughing : MonoBehaviour
{
    public Button button1; // 인스펙터 창에서 설정할 버튼 1
    public Button button2; // 인스펙터 창에서 설정할 버튼 2
    public string sceneName; // 이동할 씬의 이름
    public alphazero1 alpha;

    private bool button1Clicked = false;
    private bool button2Clicked = false;

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        button1.onClick.AddListener(() => { button1Clicked = true; CheckAllButtonsClicked(); });
        button2.onClick.AddListener(() => { button2Clicked = true; CheckAllButtonsClicked(); });
    }

    // 모든 버튼을 클릭했는지 확인하고, 모두 클릭했다면 씬 이동
    private void CheckAllButtonsClicked()
    {
        if (button1Clicked && button2Clicked)
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        alpha.Fadeone();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName);
    }
}