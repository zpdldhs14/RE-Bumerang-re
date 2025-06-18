using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임의 전반적인 상태를 관리하는 매니저 클래스입니다.
/// </summary>
public enum GameDay
{
    Day1,
    Day2,
    Day3,
    Day4,
    DayEnd
}

public class GameManager : Singleton<GameManager>
{
    private bool isPaused = false;
    public static List<int> collectedItems = new List<int>();
    static float speed = 5f, moveAccuracy = 0.15f;

    [Header("게임 진행 상태")]
    public int currentDay = 1; // 1일차부터 시작
    public string lastVisitedRoom = ""; // 마지막으로 방문한 방

    public GameDay CurrentGameDay { get; private set; } = GameDay.Day1;
    
    [SerializeField] public List<string> unlockedRoomsForMap = new List<string>();
    [HideInInspector] public string currentPlayerRoomSceneName = "";

    [Header("Map Scene Names")]
    public string firstFloorMapSceneName = "Map 1F";
    public string secondFloorMapSceneName = "Map 2F";
    public string basementMapSceneName = "Map B1F";

    // Day2 관련 게임 상태
    public bool is202PuzzleCompleted = false;  // 202호 퍼즐 완료 여부
    public bool is201PuzzleCompleted = false;  // 201호 퍼즐 완료 여부
    public bool is205PuzzleCompleted = false; // 205호 퍼즐 완료 여부

    // Day3 관련 게임 상태
    public bool hasSoap = false;  // 비누 획득 여부
    public bool hasKey = false;   // 열쇠 획득 여부
    public bool gratingRemoved = false; // 창살 제거 여부
    public bool storageUnlocked = false; // 창고 해제 여부

    // 퍼즐 관련 상태
    public bool isPuzzleCompleted = false;

    private void OnEnable()
    {
        // 씬 전환 이벤트 구독
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 씬 전환 이벤트 구독 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 이름에 따라 일차 증가
        string currentScene = scene.name;
        Debug.Log($"씬 로드됨: {currentScene}");
        
        if (currentScene == "CutScene")
        {
            currentDay = 2;
            CurrentGameDay = GameDay.Day2;
            // 2일차 시작 시 202호 퍼즐 완료 상태 초기화
            is202PuzzleCompleted = true;
            is201PuzzleCompleted = false;
        }
        else if (currentScene == "2ndnight")
        {
            currentDay = 3;
            CurrentGameDay = GameDay.Day3;
        }
        else if (currentScene == "CutScene_3rd")
        {
            currentDay = 4;
            CurrentGameDay = GameDay.Day4;
        }
    }

    private void Start()
    {
        // 초기 씬 로드 시에도 일차 설정
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    private void InitializeGameState()
    {
        // 게임 시작 시 모든 상태 초기화
        isPuzzleCompleted = false;
        unlockedRoomsForMap.Clear();
        hasSoap = false;
        hasKey = false;
        gratingRemoved = false;
        storageUnlocked = false;
        currentPlayerRoomSceneName = "";
        
        // PlayerPrefs도 초기화
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    private void SaveGameState()
    {
        // 퍼즐 완료 상태 저장
        PlayerPrefs.SetInt("PuzzleCompleted", isPuzzleCompleted ? 1 : 0);
        
        // 잠금 해제된 방 목록 저장
        string roomsToSave = string.Join(",", unlockedRoomsForMap);
        PlayerPrefs.SetString("UnlockedRooms", roomsToSave);
        
        PlayerPrefs.Save();
    }

    public void SetLastVisitedRoom(string roomId)
    {
        lastVisitedRoom = roomId;
    }

    /// <summary>
    /// 게임을 일시정지합니다.
    /// </summary>
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        EventManager.Instance.TriggerEvent("GamePaused", null);
    }

    /// <summary>
    /// 게임을 재개합니다.
    /// </summary>
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        EventManager.Instance.TriggerEvent("GameResumed", null);
    }

    public IEnumerator MoveToPoint(Transform myObject, Vector2 point)
    {
        Vector2 positiondiff = point - (Vector2)myObject.position;
        while (positiondiff.magnitude > moveAccuracy)
        {
            myObject.Translate(speed * positiondiff.normalized * Time.deltaTime);
            positiondiff = point - (Vector2)myObject.position;
            yield return null;
        }
        myObject.position = point;
    }

    public void AdvanceGameDay()
    {
        CurrentGameDay++;
        Debug.Log($"Game Day Advanced to: {CurrentGameDay}");
    }

    public void OnPlayerExitingRoom(string currentRoomId)
    {
        currentPlayerRoomSceneName = currentRoomId;
        LoadMapSceneBasedOnCurrentDay();
    }

    public void Complete202Puzzle()
    {
        is202PuzzleCompleted = true;
        // 202호 퍼즐 완료 시 201호 활성화
        if (!unlockedRoomsForMap.Contains("201"))
        {
            unlockedRoomsForMap.Add("201");
        }
        // 맵 UI 업데이트 이벤트 발생 (활성화된 방 정보 전달)
        var eventData = new Dictionary<string, string> { { "activatedRoom", "201" } };
        EventManager.Instance.TriggerEvent("UpdateMapUI", eventData);
    }

    public void Complete201Puzzle()
    {
        is201PuzzleCompleted = true;
        // 201호 퍼즐 완료 시 205호 활성화
        if (!unlockedRoomsForMap.Contains("205"))
        {
            unlockedRoomsForMap.Add("205");
        }
        // 맵 UI 업데이트 이벤트 발생 (활성화된 방 정보 전달)
        var eventData = new Dictionary<string, string> { { "activatedRoom", "205" } };
        EventManager.Instance.TriggerEvent("UpdateMapUI", eventData);
    }

    public void Complete205Puzzle()
    {
        is205PuzzleCompleted = true;
        if (!unlockedRoomsForMap.Contains("ShowerRoom"))
        {
            unlockedRoomsForMap.Add("ShowerRoom");
        }
        var eventData = new Dictionary<string, string> { { "activatedRoom", "ShowerRoom" } };
        EventManager.Instance.TriggerEvent("UpdateMapUI", eventData);
    }

    public void GetSoap()
    {
        hasSoap = true;
        Debug.Log("비누를 획득했습니다.");
    }

    public void GetKey()
    {
        hasKey = true;
        Debug.Log("열쇠를 획득했습니다.");
    }

    public void RemoveGrating()
    {
        if (hasKey)
        {
            gratingRemoved = true;
            storageUnlocked = true;
            Debug.Log("창살이 제거되었습니다.");
            // 맵 UI 업데이트 이벤트 발생
            var eventData = new Dictionary<string, string> { { "activatedRoom", "Warehouse" } };
            EventManager.Instance.TriggerEvent("UpdateMapUI", eventData);
        }
        else
        {
            Debug.Log("열쇠가 없어서 창살을 제거할 수 없습니다.");
        }
    }

    public bool CanEnterWarehouse()
    {
        return hasSoap && hasKey;
    }

    private void LoadMapSceneBasedOnCurrentDay()
    {
        string targetMapScene = "";

        switch (CurrentGameDay)
        {
            case GameDay.Day2:
                targetMapScene = secondFloorMapSceneName;
                if (currentPlayerRoomSceneName == "201")
                {
                    if (!unlockedRoomsForMap.Contains("201"))
                        unlockedRoomsForMap.Add("201");
                    if (!unlockedRoomsForMap.Contains("205"))
                        unlockedRoomsForMap.Add("205");
                }
                else
                {
                    // 퍼즐이 완료되었으면 201호 활성화
                    if (isPuzzleCompleted && !unlockedRoomsForMap.Contains("201"))
                    {
                        unlockedRoomsForMap.Add("201");
                    }
                    Debug.Log("Day 2: You can only exit from Room 201 to the map scene.");
                }
                break;

            case GameDay.Day3:
                targetMapScene = firstFloorMapSceneName;
                if (!unlockedRoomsForMap.Contains("ShowerRoom"))
                    unlockedRoomsForMap.Add("ShowerRoom");
                
                if (gratingRemoved && !unlockedRoomsForMap.Contains("Warehouse"))
                {
                    unlockedRoomsForMap.Add("Warehouse");
                }
                break;

            case GameDay.Day4:
                targetMapScene = firstFloorMapSceneName;
                if (!unlockedRoomsForMap.Contains("Bathroom"))
                    unlockedRoomsForMap.Add("Bathroom");
                
                if (currentPlayerRoomSceneName == "Bathroom" && !unlockedRoomsForMap.Contains("GuardRoom"))
                {
                    unlockedRoomsForMap.Add("GuardRoom");
                }
                break;
            
            default:
                Debug.LogWarning("Undefined game day or map scene logic. Loading default map.");
                targetMapScene = firstFloorMapSceneName;
                break;
        }

        SaveGameState(); // 맵 씬 전환 전 상태 저장

        if (!string.IsNullOrEmpty(targetMapScene))
        {
            SceneManager.LoadScene(targetMapScene);
        }
        else
        {
            Debug.LogError("No target map scene determined for current game state.");
        }
    }

    public void LoadRoomScene(string roomSceneName)
    {
        SceneManager.LoadScene(roomSceneName);
    }
}
