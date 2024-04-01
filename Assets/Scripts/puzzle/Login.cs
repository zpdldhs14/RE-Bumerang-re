using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField inputField;
    public string password;
    public GameObject login;

    public TMP_InputField sceondPassword;
    public string secondpassword;
    public GameObject secondObject;
    
    void Update()
    {
        if (inputField.text == password)
        {
            login.SetActive(true);
        }
        if(sceondPassword.text == secondpassword)
        {
            secondObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
