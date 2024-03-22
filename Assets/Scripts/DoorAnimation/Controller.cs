using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour
{
    FadeScript fade;

    void Start()
    {
        fade = FindObjectOfType<FadeScript>();

        fade.FadeOut();
    }

    void Update()
    {

    }
}