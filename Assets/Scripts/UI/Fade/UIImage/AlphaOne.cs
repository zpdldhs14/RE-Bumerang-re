using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaOne : MonoBehaviour
{
    public float duration;

    private void Start()
    {
        UIManager.Instance.FadeAlphaOne(go: this.gameObject, duration);
    }
    
    
    
}