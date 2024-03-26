using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StorageStart : typingeffect
{
    public override string m_text { get; set; } = "바깥에 무슨 소리가 들린다...";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    
}
