using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public GameObject button;
    public GameObject text;


    void Update()
    {
        // 마우스 위치에서 레이캐스팅 수행
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        // 레이캐스팅 결과 오브젝트 확인
        if (hit.collider != null)
        {
            // 오브젝트 태그 확인
            if (hit.collider.gameObject.tag == "message")
            {
                // 조사 가능 오브젝트 위에 있을 때
                text.SetActive(true);
            }
            else
            {
                text.SetActive(false);
            }
        }
        else
        {
            text.SetActive(false);
        }
    }
}
