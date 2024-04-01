using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageImmidi : MonoBehaviour
{
   public Image image;
    public Sprite newSprite;
    public Button button;
    private bool imageChanged = false;

    public void ChangeImage()
    {
        if(!imageChanged)
        {
            image.sprite = newSprite;
            imageChanged = true;
        }
        else
        {
            button.gameObject.SetActive(false);
        }
        
        
    }
}
