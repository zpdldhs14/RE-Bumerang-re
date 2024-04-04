using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimic2 : MonoBehaviour
{
    public bool isVisited = false;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        if (!isVisited)
        {
            trigger.SetActive(true);
            isVisited = true;
        }
        else
        {
            trigger.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
