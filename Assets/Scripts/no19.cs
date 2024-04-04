using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no19 : MonoBehaviour
{
    private bool isPlayerInside = true;
    public GameObject No19;
    void Update()
    {
        if (isPlayerInside && Input.GetMouseButtonDown(0))
        {
            // 마우스 포인터 아래의 오브젝트를 가져옵니다.
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // 마우스 포인터 아래의 오브젝트가 이 오브젝트인지 확인합니다.
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                No19.SetActive(true);
            }
        }
    }
}
