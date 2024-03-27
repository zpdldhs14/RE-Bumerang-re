using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonClick : MonoBehaviour
{
    public Button button;

    void Start()
    {
            button = GetComponent<Button>();

            button.onClick.AddListener(OnClickEnter);
    }

    public void OnClickEnter(){
        string ButtonName = button.name;

    switch (ButtonName)
    {
        case "1F":
            SceneManager.LoadScene(10);
            break;
        case "2F":
            SceneManager.LoadScene(3);
            break;
        case "B1F":
            SceneManager.LoadScene(11);
            break;
        default:
            break;
    }

    }

}
