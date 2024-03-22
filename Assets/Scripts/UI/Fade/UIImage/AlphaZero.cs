using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaZero : MonoBehaviour
{
    public float duration;

    void Start()
    {
        UIManager.Instance.FadeAlphaZero(this.gameObject, duration);
    }
}