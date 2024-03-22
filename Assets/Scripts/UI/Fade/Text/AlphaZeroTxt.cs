using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaZeroTxt : MonoBehaviour
{
    public float duration;

    void Start()
    {
        UIManager.Instance.AlphaZeroTxt(this.gameObject, duration);
    }
}