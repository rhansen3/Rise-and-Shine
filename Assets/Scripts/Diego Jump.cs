using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiegoJump : MonoBehaviour
{

    public LayerMask groundLayer;
    public float jumpForce = 5f;
    public float wallJumpForce = 5f;
    public float wallSlideSpeed = 2f;

    public Transform wallCheckL;
    public Transform wallCheckR;
    public Transform groundCheck;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Wall sliding
        if(IsTouchingWall() && !IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }

        // Jump button pressed
        if(Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    void Jump() {
        if(IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    bool IsTouchingWall() {
        return  Physics2D.OverlapCircle(wallCheckL.position, 0.1f, groundLayer) ||
                Physics2D.OverlapCircle(wallCheckR.position, 0.1f, groundLayer);
    }
}
