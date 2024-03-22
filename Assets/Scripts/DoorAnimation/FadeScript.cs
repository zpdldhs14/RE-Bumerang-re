using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool fadein = false;
    public bool fadeout = false;
    public float ToFade;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Opening());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein == true)
        {
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.GetComponent<Image>().DOColor(new Color(0, 0, 0, 1), 2);

        }
        if (fadeout == true)
        {

            canvasGroup.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 2);

        }
    }

    IEnumerator Opening()
    {
        yield return new WaitForSeconds(1);
        canvasGroup.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 2);

    }

    public void FadeIn()
    {
        fadein = true;
    }
    public void FadeOut()
    {
        fadeout = true;
    }
}
