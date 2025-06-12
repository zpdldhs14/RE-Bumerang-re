using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

    }



    public void FadeBlack(GameObject go, float duration)
    {
        go.GetComponent<Image>().DOColor(Color.black, duration);
    }

    public void FadeWhite(GameObject go, float duration)
    {
        go.GetComponent<Image>().DOColor(Color.white, duration);
    }

    public void FadeAlphaOne(GameObject go, float duration)
    {
        Color color = go.GetComponent<Image>().color;
        go.GetComponent<Image>().DOColor(new Color(color.r,color.g,color.b,1), duration);
    }

    public void FadeAlphaZero(GameObject go, float duration)
    {
        Color color = go.GetComponent<Image>().color;
        go.GetComponent<Image>().DOColor(new Color(color.r, color.g, color.b, 0), duration);
    }

    public void AlphaZeroTxt(GameObject go, float duration)
    {
        Color color = go.GetComponent<Text>().color;
        go.GetComponent<Text>().DOColor(new Color(color.r, color.g, color.b, 0), duration);
    }

    public void AlphaOneTxt(GameObject go, float duration)
    {
        Color color = go.GetComponent<Text>().color;
        go.GetComponent<Text>().DOColor(new Color(color.r, color.g, color.b, 1), duration);
    }

    public void ScaleOne(GameObject go, float duration)
    {
        RectTransform rect = go.GetComponent<RectTransform>();
        rect.DOScale(1, duration);
    }
    public void ScaleZero(GameObject go, float duration)
    {
        RectTransform rect = go.GetComponent<RectTransform>();
        rect.DOScale(0, duration);
    }
}
