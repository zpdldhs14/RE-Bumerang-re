using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class ItemText : MonoBehaviour
{
    TMP_Text myText;
    public TMP_Text MyText
    {
        get => myText;
        set
        {
            myText = value;
        }
    }


    private void Awake()
    {
        myText= GetComponent<TMP_Text>();
        ItemManager.Instance.MyText = this;
    }
}
