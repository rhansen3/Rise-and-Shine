using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
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

        // Player jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
