using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainAnimation : MonoBehaviour
{
    SpriteRenderer spren;
    Animator anim;
    float timer;
    bool isPaused;

    private void Awake()
    {
        spren = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        timer = 0;
    }

    private void Update()
    {
        if(isPaused)
        {
            timer += Time.deltaTime;
            anim.enabled = false;
            if(timer > 1.11f)
            {
                isPaused = false;
                anim.enabled = true;
                timer = 0;
            }
                
            return;
        }
        GetComponent<Image>().sprite = spren.sprite;
    }

    public void OffSet()
    {
        isPaused = true;
    }
}
