using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleZero : MonoBehaviour
{
    [SerializeField] float duration;
    
    void Start()
    {
        UIManager.Instance.ScaleZero(this.gameObject, duration);
    }

    
}
