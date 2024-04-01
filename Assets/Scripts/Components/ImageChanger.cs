using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image image;
    public Sprite newSprite;

    void Start()
    {
        StartCoroutine(ChangeImage());
    }

    public IEnumerator ChangeImage()
    {
        yield return new WaitForSeconds(5.0f);
        image.sprite = newSprite;
        
    }
}
