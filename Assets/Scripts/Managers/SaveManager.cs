using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    private PlayerData playerData;
    private SelectMgr selectManager;
    public static SaveManager Instance { get; private set; }
    private bool cutsceneExecuted;
    private Dictionary<string, bool> puzzleCompletionStatus = new Dictionary<string, bool>();

    private string saveFilePath;

    private void Start()
    {
        saveFilePath = Application.persistentDataPath + "/saveData";
        selectManager = FindObjectOfType<SelectMgr>();
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

    public string GetSaveFilePath(int slotNumber)
    {
        return $"{saveFilePath}{slotNumber + 1}.dat";
    }

public void SaveGameData(int slotNumber)
{
    int selectedSlot = slotNumber;
    playerData = new PlayerData(selectManager.player.transform.position);
    cutsceneExecuted = true;
    puzzleCompletionStatus = new Dictionary<string, bool>();
    SaveData saveData = new SaveData
    {
        playerData = playerData,
        cutsceneExecuted = cutsceneExecuted,
        puzzleCompletionStatus = puzzleCompletionStatus
    };
    BinaryFormatter formatter = new BinaryFormatter();
    FileStream file = File.Create(GetSaveFilePath(selectedSlot));
    formatter.Serialize(file, saveData);
    file.Close();
    Debug.Log("게임 데이터가 저장되었습니다.");
}

public void LoadGameData(int slotNumber)
{
    int selectedSlot = slotNumber;
    if (File.Exists(GetSaveFilePath(slotNumber)))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(GetSaveFilePath(slotNumber), FileMode.Open);
        SaveData saveData = (SaveData)formatter.Deserialize(file);
        file.Close();
        selectManager.player.transform.position = saveData.playerData.GetPosition();
        cutsceneExecuted = saveData.cutsceneExecuted;
        puzzleCompletionStatus = saveData.puzzleCompletionStatus;
        Debug.Log("게임 데이터가 불러와졌습니다.");
    }
    else
    {
        Debug.LogWarning("저장된 게임 데이터가 없습니다.");
    }
}


    private SaveData LoadSaveData(int slotNumber)
    {
        if (File.Exists(GetSaveFilePath(slotNumber)))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(GetSaveFilePath(slotNumber), FileMode.Open);
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

    public void SaveGameProgress(int gameProgress, int slotNumber)
    {
        SaveData saveData = LoadSaveData(slotNumber);
        saveData.gameProgress = gameProgress;
        SaveGameData(slotNumber);
    }

    public int LoadGameProgress(int slotNumber)
    {
        SaveData saveData = LoadSaveData(slotNumber);
        return saveData.gameProgress;
    }

    private void InitializePuzzleCompletionStatus()
    {
        puzzleCompletionStatus.Add("921", false);
        puzzleCompletionStatus.Add("Puzzle2", false);
        puzzleCompletionStatus.Add("Puzzle3", false);
    }

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

[System.Serializable]
public class SaveData
{
    public PlayerData playerData;
    public bool cutsceneExecuted;
    public Dictionary<string, bool> puzzleCompletionStatus;
    public int gameProgress;
}

[System.Serializable]
public class PlayerData
{
    public float positionX;
    public float positionY;
    public float positionZ;

    public PlayerData(Vector3 position)
    {
        positionX = position.x;
        positionY = position.y;
        positionZ = position.z;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(positionX, positionY, positionZ);
    }
}
