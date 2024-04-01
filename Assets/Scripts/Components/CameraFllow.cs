using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    public Transform Player;
    void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
