using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMovement : MonoBehaviour
{
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 1.0f;
    public float amplitude = 0.5f;

    public float chaseSpeed = 3.0f;
    public float chaseRange = 3.0f;

    private Vector2 startPosition;
    private Transform playerTransform;
    private bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer < chaseRange) 
        {
            isChasing = true;
        } 
        else if (isChasing && distanceToPlayer > chaseRange * 1.5)
        {
            isChasing = false;
        }

        if (isChasing) {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            playerTransform.position += (Vector3)direction * chaseSpeed * Time.deltaTime;
        }
        else {
            float newY = startPosition.y + amplitude * Mathf.Sin(verticalSpeed * Time.time);
            transform.position = new Vector2(transform.position.x + horizontalSpeed * Time.deltaTime, newY);  
        }
    }
}
