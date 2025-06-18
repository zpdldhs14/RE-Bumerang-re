using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortag : MonoBehaviour
{
   public GameObject black;
   public float duration = 2f;
   public string sceneName;
   public string currentRoomId;
   public string targetRoomId;
   public string requiredItem;
   public string messageOnLocked;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
            // 현재 방 정보 저장
            if (!string.IsNullOrEmpty(currentRoomId))
            {
                GameManager.Instance.SetLastVisitedRoom(currentRoomId);
            }

            if (string.IsNullOrEmpty(targetRoomId))
            {
                // 맵 씬으로 이동하는 경우
                // 201호에서 나갈 때는 퍼즐이 완료되어야 함
                if (currentRoomId == "201" && !GameManager.Instance.is201PuzzleCompleted)
                {
                    if (UiManager.Instance != null)
                    {
                        UiManager.Instance.ShowMessage("아직 퍼즐을 완료하지 않았습니다.");
                    }
                    return;
                }

                if (black != null)
                {
                    black.SetActive(true);
                    if (UiManager.Instance != null)
                    {
                        UiManager.Instance.FadeAlphaOne(black, duration);
                    }
                }
                StartCoroutine(ChangeSceneWithDelay());
            }
            else
            {
                // 특정 방으로 이동하는 경우
                if (MapManager.Instance != null && MapManager.Instance.IsRoomUnlocked(targetRoomId))
                {
                    if (string.IsNullOrEmpty(requiredItem) || 
                        (InventoryManager.Instance != null && InventoryManager.Instance.HasItem(requiredItem)))
                    {
                        if (black != null)
                        {
                            black.SetActive(true);
                            if (UiManager.Instance != null)
                            {
                                UiManager.Instance.FadeAlphaOne(black, duration);
                            }
                        }
                        StartCoroutine(ChangeSceneWithDelay());
                    }
                    else if (!string.IsNullOrEmpty(messageOnLocked) && UiManager.Instance != null)
                    {
                        UiManager.Instance.ShowMessage(messageOnLocked);
                    }
                }
            }
        }
   }

    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(duration);
        
        // 현재 방에서 나갈 때 다음 방을 활성화
        if (!string.IsNullOrEmpty(currentRoomId) && !string.IsNullOrEmpty(targetRoomId) && MapManager.Instance != null)
        {
            MapManager.Instance.UnlockRoom(targetRoomId);
        }
        
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
