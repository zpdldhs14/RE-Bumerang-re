using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaOneTxt : MonoBehaviour
{
    public float duration;

    private void Start()
    {
        UIManager.Instance.AlphaOneTxt(go: this.gameObject, duration);
    }
    
    
    
}