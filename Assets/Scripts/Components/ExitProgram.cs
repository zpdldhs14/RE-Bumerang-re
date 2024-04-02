using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitProgram : MonoBehaviour
{
    public void OnButtonClick()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.sfxData.GetSound("Click"));
        Application.Quit(); // 애플리케이션 종료
    }
}
