using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public float speed = 10f; // 플레이어의 이동 속도
    public GameObject buttonObject; // 활성화할 버튼 오브젝트
    public GameObject imageObject; // 활성화할 이미지 오브젝트
    public GameObject letter; // 활성화할 편지 오브젝트
    public Animator animator; // 플레이어의 애니메이터
    public SpriteRenderer spriteRenderer; // 플레이어의 스프라이트 렌더러

    private Vector3 targetPosition;
    private GameObject selectedObject = null;
    private string selectedTag = null;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(buttonObject.activeInHierarchy)
            {
                buttonObject.SetActive(false);
            }
            
            if(imageObject.activeInHierarchy)
            {
                imageObject.SetActive(false);
            }
        }

        
        // 버튼이나 이미지가 활성화되어 있지 않을 때만 플레이어가 움직일 수 있습니다.
        if (!buttonObject.activeInHierarchy && !imageObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("message") || hit.collider.gameObject.CompareTag("read") || hit.collider.gameObject.CompareTag("CD"))
                    {
                        selectedObject = hit.collider.gameObject;
                        selectedTag = hit.collider.gameObject.tag;
                    }
                }
                targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
            }

            // 플레이어를 x축 방향으로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position != targetPosition)
            {
                animator.SetBool("isWalk", true);
                if (transform.position.x < targetPosition.x)
                {
                    spriteRenderer.flipX = true;
                }
                else if (transform.position.x > targetPosition.x)
                {
                    spriteRenderer.flipX = false;
                }
            }
            else
            {
                animator.SetBool("isWalk", false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == selectedObject)
        {
            if (selectedTag == "message")
            {
                buttonObject.SetActive(true);
            }
            else if (selectedTag == "read")
            {
                imageObject.SetActive(true);
            }
            else if(selectedTag == "CD")
            {
                letter.SetActive(true);
            }
            selectedObject = null;
            selectedTag = null;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == selectedObject)
        {
            if (selectedTag == "message")
            {
                buttonObject.SetActive(false);
            }
            else if (selectedTag == "read")
            {
                imageObject.SetActive(false);
            }
            else if (selectedTag == "CD")
            {
                letter.SetActive(false);
            }

        }
    }


}
