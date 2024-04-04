using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterChange : MonoBehaviour
{
    public Image image;
    public Sprite newSprite;
    public Button button;

    void Start()
    {
        StartCoroutine(ChangeImage());
        button.onClick.AddListener(DisableButton);
    }

    public IEnumerator ChangeImage()
    {
        yield return new WaitForSeconds(0.1f);
        image.sprite = newSprite;

    }

    void DisableButton()
    {
        button.gameObject.SetActive(false);
    }
}