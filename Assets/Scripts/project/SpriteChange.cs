using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    public SpriteRenderer image;
    public Sprite newSprite;
    public Sprite originalSprite;
    public GameObject puzzle;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            image.sprite = newSprite;
            puzzle.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            image.sprite = originalSprite;
            puzzle.SetActive(false);
        }
    }
}
