using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOne : MonoBehaviour
{
    [SerializeField] float duration;

    void Start()
    {
        UiManager.Instance.ScaleOne(this.gameObject, duration);
    }

}
