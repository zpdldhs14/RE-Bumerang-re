using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaZeroTxt : MonoBehaviour
{
    public float duration;

    void Start()
    {
        UiManager.Instance.AlphaZeroTxt(this.gameObject, duration);
    }
}