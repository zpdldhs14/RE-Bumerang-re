using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class password : Login
{
    public GameObject text;

    void Update()
    {
        if (inputField.text == password)
        {
            text.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
