using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
   public Image image;
   public float speed = 0.1f;
   public Color currentColor = new Color(114, 45, 45, 255);

   void Start()
   {
       StartCoroutine(ChangeColor());
   }

   IEnumerator ChangeColor()
   {
       while(true)
       {
            for(float i = 0; i <= 1; i += Time.deltaTime * speed)
            {
                image.color = Color.Lerp(Color.white, currentColor, i);
                yield return null;
            }
            for(float i = 0; i <= 1; i += Time.deltaTime * speed)
            {
                image.color = Color.Lerp(currentColor, Color.black, i);
                yield return null;
            }
       }
   }
}
