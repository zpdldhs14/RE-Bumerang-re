using System.Collections;
using UnityEngine;

public class BoxClose : MonoBehaviour
{
    public GameObject image;
    public GameObject key;

    void Update()
    {
        if (!key.activeInHierarchy)
        {
            StartCoroutine(DisableImageAfterSeconds(1f));
        }
    }

    IEnumerator DisableImageAfterSeconds(float seconds)
    {

        yield return new WaitForSeconds(seconds);

        image.SetActive(false);
        
        if (!image.activeInHierarchy)
        {
            yield break;
        }
    }
}