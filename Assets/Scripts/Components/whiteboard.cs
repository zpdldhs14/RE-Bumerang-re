using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteboard : MonoBehaviour
{
    public GameObject no17; 
   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            no17.SetActive(true);
        }
    }
}
