using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no17 : MonoBehaviour
{
    public GameObject No17;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            No17.SetActive(true);
        }
    }
}
