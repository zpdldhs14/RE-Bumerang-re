using UnityEngine;
using UnityEngine.UI;

public class MapRoomIcon : MonoBehaviour
{
    public string sceneName;
    private Button roomButton;

    void Awake()
    {
        roomButton = GetComponent<Button>();
        if (roomButton == null)
        {
            Debug.LogError($"MapRoomIcon: No Button component found on {gameObject.name}.");
        }
        else
        {
            roomButton.onClick.AddListener(OnRoomIconClicked);
        }
    }

    public void OnRoomIconClicked()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log($"Attempting to load room: {sceneName}");
            GameManager.Instance.LoadRoomScene(sceneName);
        }
        else
        {
            Debug.LogWarning($"MapRoomIcon: sceneName is not set for {gameObject.name}.");
        }
    }
} 