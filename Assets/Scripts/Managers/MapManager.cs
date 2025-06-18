using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    [System.Serializable]
    public class RoomData
    {
        public string roomId;
        public GameObject roomObject;
        public bool isUnlocked;
        public string requiredItem;
    }

    [System.Serializable]
    public class RoomMapping
    {
        public string roomId;
        public GameObject roomIconObject;
    }

    [Header("2층 맵")]
    public List<RoomData> secondFloorRooms = new List<RoomData>();
    
    [Header("3층 맵")]
    public List<RoomData> thirdFloorRooms = new List<RoomData>();
    
    [Header("4층 맵")]
    public List<RoomData> fourthFloorRooms = new List<RoomData>();

    public List<RoomMapping> allRoomIcons;

    [Header("Day 3 Specific Objects")]
    [SerializeField] private GameObject gratingObject; // 창살 오브젝트
    [SerializeField] private Button warehouseTextButton; // 창고 텍스트 버튼

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // GameManager가 준비될 때까지 대기
        StartCoroutine(WaitForGameManager());
    }

    private IEnumerator WaitForGameManager()
    {
        // GameManager가 준비될 때까지 대기
        while (GameManager.Instance == null)
        {
            yield return null;
        }

        // 모든 방을 비활성화 상태로 시작
        DeactivateAllRooms();

        // 현재 날짜에 따라 초기 방 활성화
        switch (GameManager.Instance.CurrentGameDay)
        {
            case GameDay.Day2:
                // 2일차: 202호 퍼즐이 완료되었으면 201호만 활성화
                if (GameManager.Instance.is202PuzzleCompleted)
                {
                    Debug.Log("202호 퍼즐 완료됨, 201호 활성화");
                    ActivateRoom("201");
                }
                break;
            case GameDay.Day3:
                // 3일차: 샤워실만 활성화
                ActivateRoom("shower");
                // 창살과 창고 버튼 설정
                SetupDay3Objects();
                break;
            case GameDay.Day4:
                // 4일차: 화장실만 활성화
                ActivateRoom("toilet");
                break;
        }

        // 마지막으로 방문한 방에 따라 추가 방 활성화
        switch (GameManager.Instance.lastVisitedRoom)
        {
            case "201":
                // 201호 퍼즐이 완료되었으면 205호 활성화
                if (GameManager.Instance.is201PuzzleCompleted)
                {
                    Debug.Log("201호 퍼즐 완료됨, 205호 활성화");
                    ActivateRoom("205");
                }
                break;
            case "shower":
                ActivateRoom("storage");
                break;
            case "toilet":
                ActivateRoom("security");
                break;
        }
    }

    private void DeactivateAllRooms()
    {
        DeactivateRoomsInList(secondFloorRooms);
        DeactivateRoomsInList(thirdFloorRooms);
        DeactivateRoomsInList(fourthFloorRooms);
    }

    private void DeactivateRoomsInList(List<RoomData> rooms)
    {
        foreach (var room in rooms)
        {
            if (room.roomObject != null)
            {
                // 버튼 컴포넌트 가져오기
                Button button = room.roomObject.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = false; // 버튼 상호작용만 비활성화
                    Debug.Log($"방 {room.roomId}의 버튼 상호작용 비활성화");
                }
            }
            room.isUnlocked = false;
            Debug.Log($"방 {room.roomId}의 isUnlocked를 false로 설정");
        }
    }

    private void ActivateRoom(string roomId)
    {
        Debug.Log($"방 활성화 시도: {roomId}");
        ActivateRoomInList(secondFloorRooms, roomId);
        ActivateRoomInList(thirdFloorRooms, roomId);
        ActivateRoomInList(fourthFloorRooms, roomId);
    }

    private void ActivateRoomInList(List<RoomData> rooms, string roomId)
    {
        foreach (var room in rooms)
        {
            if (room.roomId == roomId)
            {
                room.isUnlocked = true;
                if (room.roomObject != null)
                {
                    room.roomObject.SetActive(true);
                    // 버튼 컴포넌트 가져오기
                    Button button = room.roomObject.GetComponent<Button>();
                    if (button != null)
                    {
                        button.interactable = true; // 버튼 상호작용 활성화
                        Debug.Log($"방 {roomId}의 버튼 상호작용 활성화");
                    }
                }
                break;
            }
        }
    }

    public void UnlockRoom(string roomId)
    {
        UnlockRoomInList(secondFloorRooms, roomId);
        UnlockRoomInList(thirdFloorRooms, roomId);
        UnlockRoomInList(fourthFloorRooms, roomId);
    }

    private void UnlockRoomInList(List<RoomData> rooms, string roomId)
    {
        foreach (var room in rooms)
        {
            if (room.roomId == roomId)
            {
                room.isUnlocked = true;
                if (room.roomObject != null)
                {
                    room.roomObject.SetActive(true);
                }
                break;
            }
        }
    }

    public bool IsRoomUnlocked(string roomId)
    {
        return IsRoomUnlockedInList(secondFloorRooms, roomId) ||
               IsRoomUnlockedInList(thirdFloorRooms, roomId) ||
               IsRoomUnlockedInList(fourthFloorRooms, roomId);
    }

    private bool IsRoomUnlockedInList(List<RoomData> rooms, string roomId)
    {
        foreach (var room in rooms)
        {
            if (room.roomId == roomId)
            {
                return room.isUnlocked;
            }
        }
        return false;
    }

    public bool CheckRoomRequirement(string roomId, string itemId)
    {
        return CheckRoomRequirementInList(secondFloorRooms, roomId, itemId) ||
               CheckRoomRequirementInList(thirdFloorRooms, roomId, itemId) ||
               CheckRoomRequirementInList(fourthFloorRooms, roomId, itemId);
    }

    private bool CheckRoomRequirementInList(List<RoomData> rooms, string roomId, string itemId)
    {
        foreach (var room in rooms)
        {
            if (room.roomId == roomId)
            {
                return string.IsNullOrEmpty(room.requiredItem) || room.requiredItem == itemId;
            }
        }
        return false;
    }

    private void OnEnable()
    {
        // 이벤트 구독
        EventManager.Instance.StartListening("UpdateMapUI", OnUpdateMapUI);
    }

    private void OnDisable()
    {
        // 이벤트 구독 해제
        EventManager.Instance.StopListening("UpdateMapUI", OnUpdateMapUI);
    }

    private void OnUpdateMapUI(object data)
    {
        // 먼저 전체 맵 UI 업데이트
        UpdateMapUI();

        // 그 다음 이벤트 데이터에서 활성화된 방 정보 추출하여 활성화
        if (data != null)
        {
            var eventData = data as Dictionary<string, string>;
            if (eventData != null && eventData.ContainsKey("activatedRoom"))
            {
                string activatedRoom = eventData["activatedRoom"];
                Debug.Log($"방 활성화 이벤트 수신: {activatedRoom}");
                
                // 해당 방 활성화
                ActivateRoom(activatedRoom);
            }
        }
    }

    public void UpdateMapUI()
    {
        Debug.Log("UpdateMapUI 시작");
        // 먼저 모든 방의 버튼 상호작용을 비활성화
        foreach (var room in allRoomIcons)
        {
            if (room.roomIconObject != null)
            {
                Button button = room.roomIconObject.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = false;
                    Debug.Log($"방 {room.roomId}의 버튼 상호작용 비활성화");
                }
            }
        }

        // GameManager에서 현재 활성화해야 할 방들을 가져와 활성화
        foreach (string roomId in GameManager.Instance.unlockedRoomsForMap)
        {
            Debug.Log($"GameManager에서 활성화할 방 ID: {roomId}");
            
            // 현재 층에 따라 해당하는 RoomData 리스트만 업데이트
            switch (GameManager.Instance.CurrentGameDay)
            {
                case GameDay.Day2:
                    UpdateRoomDataInList(secondFloorRooms, roomId);
                    break;
                case GameDay.Day3:
                    UpdateRoomDataInList(thirdFloorRooms, roomId);
                    break;
                case GameDay.Day4:
                    UpdateRoomDataInList(fourthFloorRooms, roomId);
                    break;
            }
        }

        // Day3 특정 오브젝트 상태 업데이트
        if (GameManager.Instance.CurrentGameDay == GameDay.Day3)
        {
            if (gratingObject != null)
            {
                gratingObject.SetActive(!GameManager.Instance.gratingRemoved);
                Button gratingButton = gratingObject.GetComponent<Button>();
                if (gratingButton != null)
                {
                    gratingButton.interactable = GameManager.Instance.hasKey && !GameManager.Instance.gratingRemoved;
                }
            }
            if (warehouseTextButton != null)
            {
                warehouseTextButton.interactable = GameManager.Instance.storageUnlocked;
            }
        }
    }

    private void UpdateRoomData(string roomId)
    {
        Debug.Log($"UpdateRoomData 시작 - 방 ID: {roomId}");
        
        // 현재 층에 따라 해당하는 RoomData 리스트만 업데이트
        switch (GameManager.Instance.CurrentGameDay)
        {
            case GameDay.Day2:
                UpdateRoomDataInList(secondFloorRooms, roomId);
                break;
            case GameDay.Day3:
                UpdateRoomDataInList(thirdFloorRooms, roomId);
                break;
            case GameDay.Day4:
                UpdateRoomDataInList(fourthFloorRooms, roomId);
                break;
        }
    }

    private void UpdateRoomDataInList(List<RoomData> rooms, string roomId)
    {
        Debug.Log($"UpdateRoomDataInList 시작 - 방 ID: {roomId}, 리스트 크기: {rooms.Count}");
        
        foreach (var room in rooms)
        {
            if (room.roomId == roomId)
            {
                room.isUnlocked = true;
                Debug.Log($"방 {roomId}의 isUnlocked를 true로 설정");
                
                if (room.roomObject != null)
                {
                    Button button = room.roomObject.GetComponent<Button>();
                    if (button != null)
                    {
                        button.interactable = true;
                        Debug.Log($"방 {roomId}의 버튼 상호작용 활성화");
                    }
                }
                break;
            }
        }
    }

    private void SetupDay3Objects()
    {
        if (gratingObject != null)
        {
            // 창살 오브젝트에 버튼 컴포넌트 추가
            Button gratingButton = gratingObject.GetComponent<Button>();
            if (gratingButton == null)
            {
                gratingButton = gratingObject.AddComponent<Button>();
            }
            gratingButton.onClick.AddListener(OnGratingClick);
            gratingButton.interactable = GameManager.Instance.hasKey && !GameManager.Instance.gratingRemoved;
        }

        if (warehouseTextButton != null)
        {
            warehouseTextButton.onClick.AddListener(OnWarehouseClick);
            warehouseTextButton.interactable = GameManager.Instance.storageUnlocked;
        }
    }

    private void OnGratingClick()
    {
        if (GameManager.Instance.hasKey && !GameManager.Instance.gratingRemoved)
        {
            GameManager.Instance.RemoveGrating();
            if (gratingObject != null)
            {
                gratingObject.SetActive(false);
            }
            if (warehouseTextButton != null)
            {
                warehouseTextButton.interactable = true;
            }
        }
    }

    private void OnWarehouseClick()
    {
        if (GameManager.Instance.CanEnterWarehouse())
        {
            Debug.Log("비눗물로 부드럽게 해서 문을 열었다");
            GameManager.Instance.LoadRoomScene("Warehouse");
        }
        else
        {
            Debug.Log("너무 뻑뻑해서 열리지 않는다, 무언가 미끄러운게 없을까?");
        }
    }
} 