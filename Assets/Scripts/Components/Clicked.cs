using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageDisplayScript : MonoBehaviour
{
    public static ImageDisplayScript Instance;

    public List<Sprite> touchedObjectsImages; // 닿았던 오브젝트의 이미지 목록
    public Image displayImage; // 이미지를 표시할 UI Image 컴포넌트
    public GameObject subMenu;
    public GameObject player;

    private int currentImageIndex; // 현재 표시되는 이미지 인덱스
    private bool isSubMenuActive = false;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentImageIndex = 0;
        displayImage.gameObject.SetActive(false);
        isSubMenuActive = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && touchedObjectsImages.Count > 0) // 마우스 우클릭
        {
            if(isSubMenuActive)
            {
                displayImage.gameObject.SetActive(false);
                subMenu.SetActive(false);
                isSubMenuActive = false;
                player.GetComponent<ClickManager>().enabled = true;
            }
            else
            {
                displayImage.sprite = touchedObjectsImages[currentImageIndex];
                displayImage.gameObject.SetActive(true);
                subMenu.SetActive(true);
                isSubMenuActive = true;
                player.GetComponent<ClickManager>().enabled = false;
            }
        }

        // "GameObject", "read", 또는 "message" 태그를 가진 오브젝트가 활성화되었을 때
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GameObject"))
        {
            if (obj.activeSelf)
            {
                Image objectImage = obj.GetComponent<Image>();
                if (objectImage != null && !touchedObjectsImages.Contains(objectImage.sprite))
                {
                    // 닿았던 오브젝트의 이미지 목록에 추가
                    touchedObjectsImages.Add(objectImage.sprite);
                    ShowNextImage();
                }
            }
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("read"))
        {
            if (obj.activeSelf)
            {
                Image objectImage = obj.GetComponent<Image>();
                if (objectImage != null && !touchedObjectsImages.Contains(objectImage.sprite))
                {
                    // 닿았던 오브젝트의 이미지 목록에 추가
                    touchedObjectsImages.Add(objectImage.sprite);
                    ShowNextImage();
                }
            }
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("message"))
        {
            if (obj.activeSelf)
            {
                Image objectImage = obj.GetComponent<Image>();
                if (objectImage != null && !touchedObjectsImages.Contains(objectImage.sprite))
                {
                    // 닿았던 오브젝트의 이미지 목록에 추가
                    touchedObjectsImages.Add(objectImage.sprite);
                    ShowNextImage();
                }
            }
        }
       
    }

    public void ShowNextImage()
    {
        if (touchedObjectsImages.Count > 0)
        {
            currentImageIndex++;
            if (currentImageIndex >= touchedObjectsImages.Count)
            {
                currentImageIndex = 0;
            }
            displayImage.sprite = touchedObjectsImages[currentImageIndex];
        }
    }

    public void OnButtonClicked(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null && !touchedObjectsImages.Contains(buttonImage.sprite))
        {
            touchedObjectsImages.Add(buttonImage.sprite);
        }
    // 버튼을 클릭할 때마다 currentImageIndex를 증가시킵니다.
    // currentImageIndex가 touchedObjectsImages의 크기와 같거나 크면 0으로 설정하여 처음부터 다시 시작합니다.
        currentImageIndex = (currentImageIndex + 1) % touchedObjectsImages.Count;

    // currentImageIndex를 사용하여 touchedObjectsImages에서 다음 이미지를 가져와 displayImage.sprite에 설정합니다.
        displayImage.sprite = touchedObjectsImages[currentImageIndex];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameObject" && other.gameObject.activeSelf)
        {
            Image objectImage = other.gameObject.GetComponent<Image>();
            if (objectImage != null && !touchedObjectsImages.Contains(objectImage.sprite))
            {
                // 닿았던 오브젝트의 이미지 목록에 추가
                touchedObjectsImages.Add(objectImage.sprite);
            }
        }
    }
}