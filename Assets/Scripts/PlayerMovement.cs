using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    public float lastHorizontalMovement;
    public float lastVerticalMovement;

    [HideInInspector] public Vector2 input;

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input.x != 0)
        {
            lastHorizontalMovement = input.x;
        }
        if (input.y != 0)
        {
            lastVerticalMovement = input.y;
        }

        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.y);
        animator.SetFloat("movementSpeed", input.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", input.x);
            animator.SetFloat("lastMoveY", input.y);
        }
    }

    private void FixedUpdate()
    {
        Vector2 normalizedInput = input.normalized;
        rb.MovePosition(rb.position + normalizedInput * movementSpeed * Time.fixedDeltaTime);
        //rb.MovePosition(rb.position + input * movementSpeed * Time.fixedDeltaTime);
    }
}
