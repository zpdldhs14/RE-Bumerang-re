using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    [SerializeField] GameObject cam;
    float timer;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        cam.transform.Rotate(Vector3.forward*timer/3);
        if (timer > 3)
            cam.GetComponent<Camera>().orthographicSize -= Time.deltaTime;
    }
}
