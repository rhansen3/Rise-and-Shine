using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Ensure the z-coordinate is 0 in 2D space

        // Calculate the direction from the GameObject to the mouse position
        Vector3 direction = mousePos - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the GameObject to face the mouse position
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));
    }
}
