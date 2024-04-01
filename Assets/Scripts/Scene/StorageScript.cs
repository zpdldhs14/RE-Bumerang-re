using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StorageScript : MonoBehaviour
{
    // 창고버튼을 클릭 할 시, 문구 출력
    public GameObject soapObject;
    public string SceneName;
    public GameObject black;
    public float duration = 2f;

    public TMP_Text text;
    private bool soapTouched = false; 

    public void OnWarehouseButtonClick()
    {
        soapTouched = PlayerPrefs.GetInt("SoapClicked", 0) == 1;

        if (soapTouched)
        {
            text.gameObject.SetActive(true); // text를 활성화 시킴
            text.text = "비눗물로 부드럽게 해서 문을 열었다.";
            StartCoroutine(ChangeSceneWithDelay());
            SceneManager.LoadScene(SceneName); 
        }
        else
        {
            text.gameObject.SetActive(true); // text를 활성화 시킴
            text.text = "너무 빡빡해서 열리지 않는다. 무언가 미끄러운게 없을까?";
            StartCoroutine(DisableTextWithDelay());
        }
    }
    IEnumerator DisableTextWithDelay()
    {
        yield return new WaitForSeconds(duration);
        text.gameObject.SetActive(false); // text를 비활성화 시킴
    }

    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(SceneName);
    }
}


