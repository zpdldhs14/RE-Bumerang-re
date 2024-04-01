using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    // 플레이어는 발소리가 끝날 때까지 움직이지 않아야 함.
    public Transform PlayerTransform;
    public Vector3 offset;
    public AudioSource audioSource;
    public ClickManager playerMovement;
    public GameObject key;

    void OnMouseDown()
    {
        PlayerTransform.position = transform.position - offset;
        StartCoroutine(StopPlayer());
    }

    IEnumerator StopPlayer()
    {
        playerMovement.enabled = false;
        yield return new WaitUntil(() => !audioSource.isPlaying);
        playerMovement.enabled = true;
        key.SetActive(true);
    }
}
