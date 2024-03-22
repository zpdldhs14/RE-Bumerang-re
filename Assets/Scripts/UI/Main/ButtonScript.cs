using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Color defaultColor;
    public Color highlightColor;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // TextMeshProUGUI 컴포넌트의 색상을 변경합니다.
        button.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // TextMeshProUGUI 컴포넌트의 색상을 변경합니다.
        button.GetComponentInChildren<TextMeshProUGUI>().color = defaultColor;
    }

}
