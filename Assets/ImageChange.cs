using UnityEngine;

public class ImageChange : MonoBehaviour
{
    public GameObject currentdoor;
    public GameObject opendoor;
    public GameObject player;
    private bool isPlayerInside = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInside = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInside = false;
        }
    }

    void Update()
    {
        if (isPlayerInside)
        {
            ActivateDoor();
        }
        else
        {
            DeactivateDoor();
        }
    }

    void ActivateDoor()
    {
        currentdoor.GetComponent<SpriteRenderer>().enabled = false;
        opendoor.GetComponent<SpriteRenderer>().enabled = true;
    }

    void DeactivateDoor()
    {
        opendoor.GetComponent<SpriteRenderer>().enabled = false;
        currentdoor.GetComponent<SpriteRenderer>().enabled = true;
    }
}