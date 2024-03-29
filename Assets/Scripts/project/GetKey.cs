using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GetKey : MonoBehaviour
{
    public float fadeOutTime = 4.0f;
    public SpriteRenderer spriteRenderer;
    public TMP_Text text;
    public alphazero1 alpha;
    public string sceneName;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(NextLevel());
        }
       
    }

    IEnumerator NextLevel()
    {
        spriteRenderer.enabled = false;
        text.text = "열쇠를 획득했다!";
        alpha.Fadeone();
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(sceneName);
    }
}
