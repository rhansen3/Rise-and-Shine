using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    public float speed = 0.5f;
    private float backgroundWidth;

    void Start()
    {
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -backgroundWidth)
        {
            Vector2 resetPosition = new Vector2(transform.position.x + 2 * backgroundWidth, transform.position.y);
            transform.position = resetPosition;
        }
    }
}
