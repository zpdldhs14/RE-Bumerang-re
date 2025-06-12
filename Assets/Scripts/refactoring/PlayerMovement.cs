using System;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private Vector3 targetPosition;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool canMove = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(!canMove) return;

        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
        }

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        bool isMoving = transform.position != targetPosition;
        animator.SetBool("isWalk", isMoving);

        if (isMoving)
        {
            spriteRenderer.flipX = transform.position.x < targetPosition.x;
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
        if (!canMove)
        {
            animator.SetBool("isWalk", false);
        }
    }
}