using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public GameObject player;
    private PlayerData playerData;
    private Rigidbody playerRigidbody;
    private Transform playerTransform;

    private InventoryData inventoryData;

    public static SaveManager Instance { get; private set; }
    private bool cutsceneExecuted;
    private Dictionary<string, bool> puzzleCompletionStatus = new Dictionary<string, bool>();

    private string saveFilePath;

    private void Start()
    {
        saveFilePath = Application.persistentDataPath + "/saveData.dat";
        
        // 플레이어 게임오브젝트로부터 Rigidbody 컴포넌트 가져오기
        playerRigidbody = player.GetComponent<Rigidbody>();
        // 플레이어 게임오브젝트로부터 Transform 컴포넌트 가져오기
        playerTransform = player.GetComponent<Transform>();
    }

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

// 저장하기
public void SaveGameData()
{
    // 플레이어 정보 수집
    playerData = new PlayerData(player.transform.position, playerRigidbody.mass);

    // 인벤토리 정보 수집
    inventoryData = new InventoryData();
    // 인벤토리 아이템 추가

    // 컷신 실행 여부 저장
    cutsceneExecuted = true;

    // 퍼즐 완료 상태 저장
    puzzleCompletionStatus = new Dictionary<string, bool>();
    // 퍼즐 이름과 완료 여부 추가

    // 저장할 데이터를 묶어서 객체로 생성
    SaveData saveData = new SaveData
    {
        playerData = playerData,
        inventoryData = inventoryData,
        cutsceneExecuted = cutsceneExecuted,
        puzzleCompletionStatus = puzzleCompletionStatus
    };

    // 데이터를 바이너리 형태로 변환하여 파일에 저장
    BinaryFormatter formatter = new BinaryFormatter();
    FileStream file = File.Create(saveFilePath);
    formatter.Serialize(file, saveData);
    file.Close();
    Debug.Log("게임 데이터가 저장되었습니다.");
}

    // 불러오기
    public void LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            // 파일에서 데이터 불러오기
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(saveFilePath, FileMode.Open);
            SaveData saveData = (SaveData)formatter.Deserialize(file);
            file.Close();

            // 불러온 데이터로 게임 상태 업데이트
            player.transform.position = saveData.playerData.position;
            // 인벤토리 정보 업데이트


            // 컷신 실행 여부 업데이트
            cutsceneExecuted = saveData.cutsceneExecuted;

            // 퍼즐 완료 상태 업데이트
            puzzleCompletionStatus = saveData.puzzleCompletionStatus;

            Debug.Log("게임 데이터가 불러와졌습니다.");
        }
        else
        {
            Debug.LogWarning("저장된 게임 데이터가 없습니다.");
        }
    }

    // 게임 진행도 저장하기
    public void SaveGameProgress(int gameProgress)
    {
        // 데이터를 불러와서 저장
        SaveData saveData = LoadSaveData();
        saveData.gameProgress = gameProgress;

        // 저장하기
        SaveGameData(saveData);
    }

    // 게임 진행도 불러오기
    public int LoadGameProgress()
    {
        // 데이터 불러오기
        SaveData saveData = LoadSaveData();

        // 게임 진행도 반환
        return saveData.gameProgress;
    }

    // 저장된 데이터 불러오기
    private SaveData LoadSaveData()
    {
        if (File.Exists(saveFilePath))
        {
            // 파일에서 데이터 불러오기
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(saveFilePath, FileMode.Open);
            SaveData saveData = (SaveData)formatter.Deserialize(file);
            file.Close();

            return saveData;
        }
        else
        {
            Debug.LogWarning("저장된 게임 데이터가 없습니다.");
            return null;
        }
    }

    // 저장된 데이터로 게임 데이터 저장하기
    private void SaveGameData(SaveData saveData)
    {
        if (saveData != null)
        {
            // 데이터를 바이너리 형태로 변환하여 파일에 저장
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create(saveFilePath);
            formatter.Serialize(file, saveData);
            file.Close();
            Debug.Log("게임 데이터가 저장되었습니다.");
        }
        else
        {
            Debug.LogWarning("저장할 데이터가 없습니다.");
        }
    }

        // 퍼즐 완료 상태를 초기화합니다.
    private void InitializePuzzleCompletionStatus()
    {
        // 각 퍼즐의 키와 초기 완료 상태를 추가합니다.
        puzzleCompletionStatus.Add("921", false);
        puzzleCompletionStatus.Add("Puzzle2", false);
        puzzleCompletionStatus.Add("Puzzle3", false);
    }

    // 특정 퍼즐이 완료되었음을 표시합니다.
    public void MarkPuzzleCompleted(string puzzleKey)
    {
        if (puzzleCompletionStatus.ContainsKey(puzzleKey))
        {
            puzzleCompletionStatus[puzzleKey] = true;
            Debug.Log(puzzleKey + " 퍼즐이 완료되었습니다.");
        }
        else
        {
            Debug.LogWarning("퍼즐 키가 잘못되었거나 존재하지 않습니다.");
        }
    }

    // 특정 퍼즐이 완료되었는지 확인합니다.
    public bool IsPuzzleCompleted(string puzzleKey)
    {
        if (puzzleCompletionStatus.ContainsKey(puzzleKey))
        {
            return puzzleCompletionStatus[puzzleKey];
        }
        else
        {
            Debug.LogWarning("퍼즐 키가 잘못되었거나 존재하지 않습니다.");
            return false;
        }
    }
}

// 저장할 데이터 클래스
[System.Serializable]
public class SaveData
{
    public PlayerData playerData; // 플레이어 정보
    public InventoryData inventoryData; // 인벤토리 정보
    public bool cutsceneExecuted; // 컷신 실행 여부
    public Dictionary<string, bool> puzzleCompletionStatus; // 퍼즐 완료 상태
    public int gameProgress; // 게임 진행도
}

// 플레이어 정보 클래스
[System.Serializable]
public class PlayerData
{
    public Vector3 position; // 플레이어 위치
    public float mass; // 플레이어 질량

    public PlayerData(Vector3 position, float mass)
    {
        this.position = position;
        this.mass = mass;
    }
}

// 인벤토리 정보 클래스
[System.Serializable]
public class InventoryData
{
    public List<string> items; // 인벤토리 아이템
}