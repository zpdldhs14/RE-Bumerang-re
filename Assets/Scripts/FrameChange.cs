using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FrameChange : MonoBehaviour
{
    public Sprite newSprite; // 바꿀 스프라이트
    public GameObject cabinetClosed; // 캐비넷 문 오브젝트
    public GameObject cabinetOpen; // 캐비넷 문 열림 오브젝트

    private SpriteRenderer image; // 액자 오브젝트의 이미지
    private bool isChanged = false; // 이미지가 바뀌었는지 여부

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (!isChanged)
        {
            // 이미지를 바꿉니다.
            image.sprite = newSprite;
            isChanged = true;

            // 모든 액자 오브젝트의 이미지가 바뀌었는지 확인합니다.
            FrameChange[] frames = FindObjectsOfType<FrameChange>();
            foreach (FrameChange frame in frames)
            {
                if (!frame.isChanged)
                {
                    // 아직 바뀌지 않은 액자 오브젝트가 있으면 더 이상 진행하지 않습니다.
                    return;
                }
            }

            // 모든 액자 오브젝트의 이미지가 바뀌었으면 캐비넷 문 오브젝트를 비활성화하고 캐비넷 문 열림 오브젝트를 활성화합니다.
            cabinetClosed.SetActive(false);
            cabinetOpen.SetActive(true);
            foreach (FrameChange frame in frames)
            {
                StartCoroutine(ChangeColorToBlack(frame.image, 1f));
            }
        }
    }

    IEnumerator ChangeColorToBlack(SpriteRenderer renderer, float duration)
    {
        Color originalColor = renderer.color;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            renderer.color = Color.Lerp(originalColor, Color.black, t);
            yield return null;
        }

        renderer.color = Color.black;
    }
}