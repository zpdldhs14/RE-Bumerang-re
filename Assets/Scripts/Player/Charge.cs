using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public SpriteRenderer parentSpren;
    public SpriteRenderer mySpren;

    private void Awake()
    {
        mySpren = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (parentSpren.flipX == false)
        {
            mySpren.flipX = false;
            transform.localPosition = new Vector2(0.2f, 0);
        }

        else
        {
            mySpren.flipX = true;
            transform.localPosition = new Vector2(-0.2f, 0);
        }

    }


    public void ActiveTrue()
    {
        gameObject.SetActive(true);
    }

    public void ActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
