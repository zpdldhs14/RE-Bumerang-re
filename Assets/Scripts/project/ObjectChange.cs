using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectChange : MonoBehaviour
{
   public ImageDisplayScript imageDisplayScript; // ImageDisplayScript의 참조
    private int currentImageIndex = 0; // 현재 사용할 액자 이미지의 인덱스

    public UnityEvent onAllImagesChanged;

    public void OnMouseDown() // 오브젝트를 클릭했을 때
    {
        if (imageDisplayScript.touchedObjectsImages.Count > currentImageIndex) // 인벤토리에 액자의 이미지가 충분히 있으면
        {
            Sprite frameImage = imageDisplayScript.touchedObjectsImages[currentImageIndex]; // 인벤토리에서 액자의 이미지를 가져옴
            GetComponent<SpriteRenderer>().sprite = frameImage; // 오브젝트에 액자의 이미지를 설정
            currentImageIndex++; // 다음 액자 이미지를 사용하도록 인덱스를 증가

            if(currentImageIndex >= imageDisplayScript.touchedObjectsImages.Count) // 모든 액자 이미지를 사용했으면
            {
                onAllImagesChanged.Invoke(); // 이벤트 호출
            }
        }
    }
}
