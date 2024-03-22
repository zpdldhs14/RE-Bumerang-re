using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWhite : MonoBehaviour
{
    public float duration;

    void Start()
    {
        UIManager.Instance.FadeWhite(this.gameObject, duration);
    }
}
