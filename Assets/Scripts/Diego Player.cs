using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiegoPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Player movement
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Flip the player sprite based on movement direction
        if (moveDirection > 0) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveDirection < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
