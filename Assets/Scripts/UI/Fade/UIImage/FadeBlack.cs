using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
{
    public float duration;
    void Start()
    {
        UIManager.Instance.FadeBlack(this.gameObject, duration);
    }
}
