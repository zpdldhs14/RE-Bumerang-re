using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphazero1 : MonoBehaviour
{
    public float duration;

   public void Fadeone()
    {
        UiManager.Instance.FadeAlphaOne(go: this.gameObject, duration);
    }
}
