using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    public static List<PlayerMove> moveableObjects = new List<PlayerMove>();
    private Vector3 target;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        moveableObjects.Add(this);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           target.z = transform.position.z;
           float directionX = target.x - transform.position.x;
           spriteRenderer.flipX = directionX < 0;
           animator.SetBool("isWalk", true);
        }
        if (Vector3.Distance(transform.position, target) == 0.0f)
        {
            animator.SetBool("isWalk", false);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

    }


}
