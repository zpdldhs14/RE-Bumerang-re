using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideonbush : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject door;
    public GameObject opendoor;
    public SpriteRenderer spriteRenderer;
    private int originalLayer = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalLayer = spriteRenderer.sortingOrder;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            door.GetComponent<SpriteRenderer>().enabled = false;
            opendoor.GetComponent<SpriteRenderer>().enabled = true;
            spriteRenderer.sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
            audioSource.Play();
            StartCoroutine(Opendoor());
        }
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            spriteRenderer.sortingOrder = originalLayer;
        }
    }

    IEnumerator Opendoor()
    {
        yield return new WaitForSeconds(0.3f);
        opendoor.GetComponent<SpriteRenderer>().enabled = false;
        door.GetComponent<SpriteRenderer>().enabled = true;
        
    }
}
