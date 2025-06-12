using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
{
    public float duration;
    void Start()
    {
        UiManager.Instance.FadeBlack(this.gameObject, duration);
    }
}
