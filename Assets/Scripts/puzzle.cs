using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle : MonoBehaviour
{
    public Button cutRedButton;
    public Button cutBlueButton;
    public Button cutYellowButton;
    public Button connectRedButton;
    public Button connectBlueButton;
    public Button connectYellowButton;
    public Image backgroundImage;

    public Sprite redLineCut;
    public Sprite blueLineCut;
    public Sprite yellowLineCut;
    public Sprite redAndblueCut;
    public Sprite redAndYellowCut;
    public Sprite blueAndYellowCut;
    public Sprite AllCut;
    public Sprite AllConnected;


    public TMP_Text text;
    public Collider2D door;
    public GameObject gimic;

    private int redLineState = 1; // 0: 끊어짐, 1: 연결됨
    private int blueLineState = 1;
    private int yellowLineState = 1;

    private void Start()
    {
        cutRedButton.onClick.AddListener(() => { redLineState = 0; UpdateBackgroundImage(); });
        cutBlueButton.onClick.AddListener(() => { blueLineState = 0; UpdateBackgroundImage(); });
        cutYellowButton.onClick.AddListener(() => { yellowLineState = 0; UpdateBackgroundImage(); });
        connectRedButton.onClick.AddListener(() => { redLineState = 1; UpdateBackgroundImage(); });
        connectBlueButton.onClick.AddListener(() => { blueLineState = 1; UpdateBackgroundImage(); });
        connectYellowButton.onClick.AddListener(() => { yellowLineState = 1; UpdateBackgroundImage(); });
    }

    private void UpdateBackgroundImage()
    {
        if (redLineState == 0 && blueLineState != 0 && yellowLineState != 0)
        {
            // 빨간색 선만 끊어진 경우
            backgroundImage.sprite = redLineCut;
        }
        else if (blueLineState == 0 && redLineState != 0 && yellowLineState != 0)
        {
            // 파란색 선만 끊어진 경우
            backgroundImage.sprite = blueLineCut;
        }
        else if (yellowLineState == 0 && redLineState != 0 && blueLineState != 0)
        {
            // 노란색 선만 끊어진 경우
            backgroundImage.sprite = yellowLineCut;
            text.text = "잠금이 해제되었습니다.";
            gimic.SetActive(false);
            door.enabled = true;
        }
        else if (redLineState == 0 && blueLineState == 0 && yellowLineState != 0)
        {
            // 빨간색과 파란색 선만 끊어진 경우
            backgroundImage.sprite = redAndblueCut;
        }
        else if (redLineState == 0 && blueLineState != 0 && yellowLineState == 0)
        {
            // 빨간색과 노란색 선만 끊어진 경우
            backgroundImage.sprite = redAndYellowCut;
        }
        else if (redLineState != 0 && blueLineState == 0 && yellowLineState == 0)
        {
            // 파란색과 노란색 선만 끊어진 경우
            backgroundImage.sprite = blueAndYellowCut;
            text.text = "비상 잠금이 작동되었습니다.";
        }
        else if (redLineState == 0 && blueLineState == 0 && yellowLineState == 0)
        {
            // 모든 선이 끊어진 경우
            backgroundImage.sprite = AllCut;
        }
        else
        {
            // 모든 선이 연결된 경우
            backgroundImage.sprite = AllConnected;
        }
    }

}