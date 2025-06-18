using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class InputText : MonoBehaviour
{
   public TMP_InputField inputField;
   public Button button;
   public Button button2;
   public TextMeshProUGUI text;
   public string answer;
   public string answer2;
   public string answer3;
   public AudioSource sound;
   public GameObject Letter;
   public GameObject black;
   public GameObject vent;

   private int clickCount = 0;

   void Start()
   {
    button.onClick.AddListener(OnClick);
    inputField.onEndEdit.AddListener(delegate {OnClick(); });
   }


   public void Oncliked()
   {
        button.gameObject.SetActive(false);
        sound.Play();
        vent.SetActive(false);
        Letter.SetActive(true);
        GameManager.Instance.Complete205Puzzle();
    }
    public void LetterClicked()
    {
        button.gameObject.SetActive(false);
        sound.Play();
        Letter.SetActive(true);
    }

    public void Goto205()
    {
        button2.gameObject.SetActive(false);
        GameManager.Instance.Complete201Puzzle();
        UiManager.Instance.FadeAndLoadScene(black, 3.0f, 4);
    }

   public void OnClick()
   {
        if (inputField.text == answer)
        {
            if (Letter.activeSelf == false)
            {
                LetterClicked();
            }
        }
        else if(inputField.text == answer2)
        {
           Goto205();
        }
        else if(inputField.text == answer3)
        {
            Oncliked();
        }
        else
        {
            text.text = "Wrong Password";
        }
   }    
}
