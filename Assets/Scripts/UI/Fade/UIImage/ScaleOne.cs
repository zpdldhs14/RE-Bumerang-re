using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOne : MonoBehaviour
{
    [SerializeField] float duration;

    void Start()
    {
        UIManager.Instance.ScaleOne(this.gameObject, duration);
    }

}
