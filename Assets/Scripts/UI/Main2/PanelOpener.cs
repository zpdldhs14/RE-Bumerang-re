using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;
    public GameObject button2;
    public GameObject button3;
    public void OpenPanel()
    {
        if (panel != null)
        {
            bool buttonactive = button.activeSelf;
            bool buttonactive1 = button.activeSelf;
            bool buttonactive2 = button.activeSelf;
            bool isActive = panel.activeSelf;
            button.SetActive(!buttonactive);
            button2.SetActive(!buttonactive1);
            button3.SetActive(!buttonactive2);
            panel.SetActive(!isActive);
        }
    }
}
