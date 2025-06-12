using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaZero : MonoBehaviour
{
    public float duration;

    void Start()
    {
        UiManager.Instance.FadeAlphaZero(this.gameObject, duration);
    }

    void Update()
    {
        Image image = gameObject.GetComponent<Image>();
        if(image.color.a == 0)
        {
            gameObject.SetActive(false);
        }
    }
}