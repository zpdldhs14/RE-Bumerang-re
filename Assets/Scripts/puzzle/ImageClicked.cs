using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClicked : MonoBehaviour
{
   public void OnPointerClick(PointerEventData eventData)
   {
    this.gameObject.SetActive(false);
   }
}
