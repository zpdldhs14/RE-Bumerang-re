using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject buttonObject; // Assign the button GameObject in the inspector
    public GameObject imageObject; // Assign the image GameObject in the inspector
    private bool hascollied = false;
    private List<GameObject> collidedObjects = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collidedObjects.Count == 0 && (other.gameObject.CompareTag("message") || other.gameObject.CompareTag("read")))
        {
            collidedObjects.Add(other.gameObject);
            HandleCollision(other.gameObject);
        }
    }

    void OnMouseDown()
    {
        foreach (var obj in collidedObjects)
        {
            if (obj == gameObject)
            {
                HandleCollision(obj);
                break;
            }
        }
    }

    private void HandleCollision(GameObject obj)
    {
        if (obj.CompareTag("message"))
        {
            // Handle collision with "message" object
            Debug.Log("Message");
            buttonObject.SetActive(true);
            hascollied = true;
        }
        else if (obj.CompareTag("read"))
        {
            // Handle collision with "read" object
            Debug.Log("read");
            imageObject.SetActive(true);
            hascollied = true;
        }
    }
}