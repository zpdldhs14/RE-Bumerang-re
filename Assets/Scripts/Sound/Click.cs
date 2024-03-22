using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    
    public void ClickSound()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.sfxData.GetSound("Click"));
    }

    
}
