using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteWobble : MonoBehaviour 
{

    void Start() {
        transform.DOMove(transform.position + new Vector3(0.1f, 0.1f, 0), 1.0f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
