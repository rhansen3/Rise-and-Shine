using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    // public float wallSlideSpeed = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float maxJumpTime = 0.5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTime;
    public Vector2 startingLocation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingLocation = transform.position;
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        //comment
        // Player movement
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Flip the player sprite based on movement direction
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // Wall sliding
        // if(IsTouchingWall() && !isGrounded) {
        //     rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        // }

        // Player jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTime = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (isJumping && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }

        if (isJumping)
        {
            jumpTime -= Time.deltaTime;
            if (jumpTime <= 0)
            {
                isJumping = false;
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
            }
        }
    }

    // bool IsTouchingWall() {
    //     return  Physics2D.OverlapCircle(wallCheckL.position, 0.1f, groundLayer) ||
    //             Physics2D.OverlapCircle(wallCheckR.position, 0.1f, groundLayer);
    // }
}
