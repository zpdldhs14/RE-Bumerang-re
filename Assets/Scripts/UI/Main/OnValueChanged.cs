using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins.Options;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChanged : MonoBehaviour
{
   [SerializeField] private TMP_Dropdown resolutionDropdown;

   private Resolution[] resolutions;
   private List<Resolution> resolutionList = new List<Resolution>();

   private float currentRefreshRate;
   private int currentResolutionIndex = 0;

   void Start()
   {
        resolutions = Screen.resolutions;
    
        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        Debug.Log("Current Refresh Rate: " + currentRefreshRate);
    
        for (int i = 0; i < resolutions.Length; i++)
        {
            Debug.Log("Resolution: " + resolutions[i]);
            if(resolutions[i].refreshRate == currentRefreshRate)
            {
                resolutionList.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i = 0; i < resolutionList.Count; i++)
        {
            string option = resolutionList[i].width + " x " + resolutionList[i].height;
            options.Add(option);
            if(resolutionList[i].width == Screen.currentResolution.width && resolutionList[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
   }

   public void SetResolution(int resolutionIndex)
   {
       Resolution resolution = resolutionList[resolutionIndex];
       Screen.SetResolution(resolution.width, resolution.height, true);
   }

}
