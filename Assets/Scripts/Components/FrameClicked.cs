using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FrameClicked : MonoBehaviour
{
    public ImageDisplayScript display;
    public Sprite sprite;
    public GameObject ShowFrame;

    public void OnMouseDown()
    {
        ShowFrame.SetActive(true);
        if(!display.touchedObjectsImages.Contains(sprite))
        {
            display.touchedObjectsImages.Add(sprite);
        }
    }
}