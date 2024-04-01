using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Puzzle : MonoBehaviour
{
    public Button puzzle1;//빨강
    public Button puzzle2;//파랑
    public Button puzzle3;//노랑
    public GameObject background;

    public Sprite newSprite1; // 빨강 선이 짤린 이미지
    public Sprite newSprite2; // 파랑 선이 짤린 이미지
    public Sprite newSprite3; // 노랑 선이 짤린 이미지

    public Sprite newSprite4; // 빨강과 파랑 선이 짤린 이미지, 노랑 선이 이어진 이미지
    public Sprite newSprite5; // 빨강과 노랑 선이 짤린 이미지, 파랑 선이 이어진 이미지
    public Sprite newSprite6; // 파랑과 노랑 선이 짤린 이미지, 빨강 선이 이어진 이미지

    public Sprite cuttingSprite; //다 짤린 이미지

    public Sprite newSprite7; // 빨강, 파랑, 노랑 선이 이어진 이미지
    public Sprite connectedSprite; // 이어진 이미지

    private bool isPuzzle1Clicked = false;
    private bool isPuzzle2Clicked = false;
    private bool isPuzzle3Clicked = false;

    bool wasPuzzle1ClickedLast = false;
    bool wasPuzzle2ClickedLast = false;
    bool wasPuzzle3ClickedLast = false;

    void Start()
    {
        puzzle1.onClick.AddListener(() => { UpdateClickStatus(1); CheckAndChangeBackground(newSprite1); });
        puzzle2.onClick.AddListener(() => { UpdateClickStatus(2); CheckAndChangeBackground(newSprite2); });
        puzzle3.onClick.AddListener(() => { UpdateClickStatus(3); CheckAndChangeBackground(newSprite3); });
    }

    void UpdateClickStatus(int puzzleNumber)
    {
        wasPuzzle1ClickedLast = isPuzzle1Clicked;
        wasPuzzle2ClickedLast = isPuzzle2Clicked;
        wasPuzzle3ClickedLast = isPuzzle3Clicked;

        isPuzzle1Clicked = puzzleNumber == 1;
        isPuzzle2Clicked = puzzleNumber == 2;
        isPuzzle3Clicked = puzzleNumber == 3;
    }
    void Update()
    {
        /*if (Input.GetMouseButtonDown(1)) // 우클릭 감지
        {
            Image image = background.GetComponent<Image>();
            image.sprite = connectedSprite;
        }*/
    }

    void CheckAndChangeBackground(Sprite sprite)
    {
        Image image = background.GetComponent<Image>();
        if ((wasPuzzle1ClickedLast && isPuzzle2Clicked) || (wasPuzzle2ClickedLast && isPuzzle1Clicked))
        {
            image.sprite = newSprite4;
        }
        else if ((wasPuzzle1ClickedLast && isPuzzle3Clicked) || (wasPuzzle3ClickedLast && isPuzzle1Clicked))
        {
            image.sprite = newSprite5;
        }
        else if ((wasPuzzle2ClickedLast && isPuzzle3Clicked) || (wasPuzzle3ClickedLast && isPuzzle2Clicked))
        {
            image.sprite = newSprite6;
        }
        else
        {
            if(isPuzzle1Clicked)
            {
                image.sprite = newSprite1;
                isPuzzle1Clicked = false;
            }
            if(isPuzzle2Clicked)
            {
                image.sprite = newSprite2;
                isPuzzle2Clicked = false;
            }
            if(isPuzzle3Clicked)
            {
                image.sprite = newSprite3;
                isPuzzle3Clicked = false;
            }
        }
    }
}