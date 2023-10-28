using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightable : MonoBehaviour
{
    public float health = 3.0f;
    public float fullHealth = 3.0f;
    private bool displayed = false;
    bool lit = true;
    // Start is called before the first frame update
    void Start()
    {
        lit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lit)
        {
            health -= Time.deltaTime * 0.5f;
        }
        if (!displayed && health < 0.0f)
        {
            Debug.Log(gameObject.name + " died");
            displayed = true;
        }
    }

    public void lightUp()
    {
        lit = true;
    }

    public void lightOff()
    {
        lit = false;
        health = fullHealth;
    }
}
