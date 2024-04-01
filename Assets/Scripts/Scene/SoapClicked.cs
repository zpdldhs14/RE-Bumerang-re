using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapClicked : MonoBehaviour
{
    public void OnSoapButtonClick()
    {
        PlayerPrefs.SetInt("SoapClicked", 1); // soap 버튼이 클릭되었음을 저장
    }
}
