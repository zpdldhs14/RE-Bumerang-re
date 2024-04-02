using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SelectMgr : MonoBehaviour
{
    public GameObject saveSlotWindow;
    public Text[] slotText;
    public SaveManager saveManager;
    public GameObject player; // 플레이어 GameObject

    public int selectedSlot = 0;

    private void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        if (saveManager == null)
        {
            Debug.LogError("SaveManager가 할당되지 않았습니다.");
            return;
        }

        if (saveSlotWindow == null)
        {
            Debug.LogError("Save Slot Window가 할당되지 않았습니다.");
            return;
        }

        saveSlotWindow.SetActive(true);
        RefreshSlotTexts();
    }

    private void RefreshSlotTexts()
    {
        for (int i = 0; i < slotText.Length; i++)
        {
            if (File.Exists(saveManager.GetSaveFilePath(i)))
            {
                slotText[i].text = "SaveData " + (i + 1);
            }
            else
            {
                slotText[i].text = "Empty";
            }
        }
    }

    public void SaveButtonClicked()
    {

        saveManager.SaveGameData(selectedSlot);
        saveSlotWindow.SetActive(false);
    }

    public void LoadButtonClicked()
    {

        saveManager.LoadGameData(selectedSlot - 1);
        saveSlotWindow.SetActive(false);
    }

    public void SlotButtonClicked(int slotNumber)
    {
        selectedSlot = slotNumber;
    }
}
