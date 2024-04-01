using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    public Texture2D cursorOnObject; // 조사 가능 오브젝트 위에 있을 때 커서 모양
    public Texture2D cursorDefault; // 기본 커서 모양
    public Texture2D cursorStop; // 조사 불가능 오브젝트 위에 있을 때 커서 모양
    public Texture2D cursorRead; // 읽기 가능 오브젝트 위에 있을 때 커서 모양

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
                Cursor.SetCursor(cursorOnObject, Vector2.zero, CursorMode.Auto);

                // 조사 기능 구현 (예: OnMouseOver 이벤트 발생)
            }
            else if(hit.collider.gameObject.tag == "read")
            {
                // 읽기 가능 오브젝트 위에 있을 때
                Cursor.SetCursor(cursorRead, Vector2.zero, CursorMode.Auto);

                // 읽기 기능 구현 (예: OnMouseOver 이벤트 발생)
            }
            else if(hit.collider.gameObject.tag == "CD")
            {
                // 조사 불가능 오브젝트 위에 있을 때
                Cursor.SetCursor(cursorStop, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                // 조사 불가능 오브젝트 위에 있을 때
                Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
            }
        }
        else
        {
            // 마우스가 오브젝트 위에 없을 때
            Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
        }
    }
}
