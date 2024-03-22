using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    [Header("# Face Images")]
    public GameObject vie;
    public GameObject vito;

    [Header("# Text")]
    public Text mytext;

    [Header("# Buttons")]
    public GameObject buttonLeft;
    public GameObject buttonRight;

    

    private void Update()
    {
        
    }


    public void PressButton()
    {
        if(buttonLeft.activeSelf)
        {
            buttonLeft.SetActive(false);
            buttonRight.SetActive(true);
        }
        else if (!buttonLeft.activeSelf)
        {
            buttonLeft.SetActive(true);
            buttonRight.SetActive(false);
        }
    }
}
