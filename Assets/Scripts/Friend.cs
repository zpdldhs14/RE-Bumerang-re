using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    public Rigidbody2D rigid;
    public Collider2D coll;
    public float maxSpeed;
    Vector3 offset = new Vector2(-1.5f, 0);
    Vector3 dirVec = new Vector3();

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponentInChildren<Rigidbody2D>();
        coll = GetComponentInChildren<Collider2D>();
    }



    void Update()
    {
        dirVec = target.position + offset - transform.position;

        if (dirVec.magnitude <= maxSpeed)
            rigid.velocity = new Vector3(dirVec.x, rigid.velocity.y, 0);
        else
            rigid.velocity = dirVec.normalized * maxSpeed;

        if (rigid.velocity.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        if (rigid.velocity.magnitude > 0.2f)
            anim.SetFloat("RunState", rigid.velocity.magnitude / 6);
        else
            anim.SetFloat("RunState", 0);

    }
}
