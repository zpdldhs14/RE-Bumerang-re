using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonObj;
    [SerializeField] private GameObject imageObj;
    [SerializeField] private GameObject letter;
    
    private static UIManager _instance;
    public static UIManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowUI(string type)
    {
        switch (type)
        {
            case "messeage":
                buttonObj.SetActive(true);
                break;
            case "CD":
                imageObj.SetActive(true);
                break;
            case "read":
                letter.SetActive(true);
                break;
        }
    }

    public void HideUI(string type)
    {
        switch (type)
        {
            case "messeage":
                buttonObj.SetActive(false);
                break;
            case "CD":
                imageObj.SetActive(false);
                break;
            case "read":
                letter.SetActive(false);
                break;
        }
    }

    public void HideAllUI()
    {
        buttonObj.SetActive(false);
        imageObj.SetActive(false);
        letter.SetActive(false);
    }

    public bool IsAnyUIActive()
    {
        return buttonObj.activeInHierarchy || imageObj.activeInHierarchy || letter.activeInHierarchy;
    }
}