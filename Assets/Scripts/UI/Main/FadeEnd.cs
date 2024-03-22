using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEnd : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    float timer;

    void Start()
    {
        timer = 0;
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 3)
        {
            buttons.SetActive(true);
        }
    }
}
