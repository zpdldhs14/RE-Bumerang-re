using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bilicome : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform 컴포넌트
    public Transform targetPosition; // 플레이어가 이동할 위치
    public float moveSpeed = 1f; // 플레이어의 이동 속도
    public TMP_Text text; // 대화 내용을 표시할 Text 컴포넌트
    public string SceneName; // 이동할 씬의 이름

    public CameraShake cameraShake; //CameraShake 스크립트에 접근하기 위한 변수
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        if (cameraShake == null)
        {
            Debug.LogError("CameraShake 컴포넌트를 찾을 수 없습니다.");
        }
        else
        {
            cameraShake.cameraTransform = player;
        }
        text.text = "빌리가 문앞으로 오라고 손짓을 한다";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // 플레이어가 특정 오브젝트에 닿았을 때
        {
            other.gameObject.GetComponent<ClickManager>().enabled = false; // 플레이어의 움직임을 멈춤
            text.text = "...";
            StartCoroutine(MovePlayerToTargetPosition()); // 플레이어를 특정 위치까지 이동
        }
    }

    IEnumerator MovePlayerToTargetPosition()
    {
        yield return new WaitForSeconds(1.0f);
        text.enabled = false; // 대화 내용을 숨김
        yield return new WaitForSeconds(5.0f);
        while (Vector2.Distance(player.position, targetPosition.position) > 0.01f) // 플레이어가 목표 위치에 도달할 때까지
        {
            player.position = Vector2.MoveTowards(player.position, targetPosition.position, moveSpeed * Time.deltaTime); // 플레이어를 목표 위치로 이동

            // 플레이어의 스프라이트를 뒤집음
            SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }

            yield return null;
        }
        GlitchWhenNear glitchEffect = GetComponent<GlitchWhenNear>(); // GlitchWhenNear 컴포넌트를 가져옴
        if (glitchEffect != null)
        {
            
        }
        SceneManager.LoadScene(SceneName); // Scene2 씬으로 전환
    }


}
