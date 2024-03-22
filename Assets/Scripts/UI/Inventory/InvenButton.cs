using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenButton : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    RectTransform myRect;
    bool isEnd;

    private void Awake()
    {
        myRect = GetComponent<RectTransform>();
    }

    

    
    public void CloseInventory()
    {
        StartCoroutine(CloseInven());
    }

    IEnumerator CloseInven()
    {
        if (myRect.localScale.y == 1 && !isEnd)
        {
            myRect.localScale = new Vector3(1, -1, 1);
            isEnd = true;
            while (rect.rect.height > 120 || rect.anchoredPosition.y < -50)
            {
                rect.sizeDelta = new Vector2(rect.rect.width, Mathf.Lerp(rect.rect.height, 110, Time.deltaTime * 3));
                rect.anchoredPosition = new Vector2(0, Mathf.Lerp(rect.anchoredPosition.y, -30, Time.deltaTime * 5));
                yield return null;
            }
            isEnd = false;
        }
            

        else if(myRect.localScale.y == -1 && !isEnd)
        {
            myRect.localScale = new Vector3(1, 1, 1);
            isEnd = true;
            while (rect.rect.height < 1000 || rect.anchoredPosition.y > -200)
            {
                rect.sizeDelta = new Vector2(rect.rect.width, Mathf.Lerp(rect.rect.height, 1020, Time.deltaTime * 3));
                rect.anchoredPosition = new Vector2(0, Mathf.Lerp(rect.anchoredPosition.y, -220, Time.deltaTime * 5));
                yield return null;
            }
            isEnd = false;
        }



    }
}
