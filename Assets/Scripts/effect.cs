using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class effect : MonoBehaviour
{
    public float duration = 1f; // 펄스 효과의 지속 시간
    public Vector3 punch = new Vector3(0.1f, 0.1f, 0); // 펄스 효과의 강도

    // Start is called before the first frame update
    void Start()
    {
        // 펄스 효과를 시작합니다.
        transform.DOPunchScale(punch, duration).SetLoops(-1, LoopType.Yoyo);
    }
}