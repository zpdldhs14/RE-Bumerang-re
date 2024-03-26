using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField inputField;
    public string password;
    public GameObject login;
    
    void Update()
    {
        if (inputField.text == password)
        {
            login.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
