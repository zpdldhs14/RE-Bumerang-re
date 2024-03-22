using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class events : MonoBehaviour
{
   // 캐릭터랑 message 태그를 가진 오브젝트랑 충돌 하였을 때, button이 활성화 되게 하는 것.
   public GameObject button;
   public GameObject sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "message")
        {
          button.SetActive(true);
        }
        else if(collision.gameObject.tag == "read")
        {
          sprite.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "message")
        {
          button.SetActive(false);
        }
        else if(collision.gameObject.tag == "read")
        {
          sprite.SetActive(false);
        }
    }
}
