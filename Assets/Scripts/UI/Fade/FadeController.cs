using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class FadeController : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private bool autoStart = false;
    [SerializeField] private FadeType fadeType = FadeType.AlphaOne;

    private Image image;
    private Text text;
    private RectTransform rectTransform;

    public enum FadeType
    {
        Black,
        White,
        AlphaOne,
        AlphaZero,
        ScaleOne,
        ScaleZero
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (autoStart)
        {
            ExecuteFade();
        }
    }

    public void ExecuteFade()
    {
        switch (fadeType)
        {
            case FadeType.Black:
                UiManager.Instance.FadeBlack(gameObject, duration);
                break;
            case FadeType.White:
                UiManager.Instance.FadeWhite(gameObject, duration);
                break;
            case FadeType.AlphaOne:
                if (text != null)
                    UiManager.Instance.AlphaOneTxt(gameObject, duration);
                else
                    UiManager.Instance.FadeAlphaOne(gameObject, duration);
                break;
            case FadeType.AlphaZero:
                if (text != null)
                    UiManager.Instance.AlphaZeroTxt(gameObject, duration);
                else
                    UiManager.Instance.FadeAlphaZero(gameObject, duration);
                break;
            case FadeType.ScaleOne:
                UiManager.Instance.ScaleOne(gameObject, duration);
                break;
            case FadeType.ScaleZero:
                UiManager.Instance.ScaleZero(gameObject, duration);
                break;
        }
    }

    public void SetFadeType(FadeType type)
    {
        fadeType = type;
    }

    public void SetDuration(float newDuration)
    {
        duration = newDuration;
    }
} 