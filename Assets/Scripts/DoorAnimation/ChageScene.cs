using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChageScene : MonoBehaviour
{
    FadeScript fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeScript>();
    }

    public IEnumerator _ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Inside_store");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(_ChangeScene());
        }
    }
}
