using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    public tempPlayer playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collide){
        if(collide.gameObject.tag == "Player"){
            playerMovement.gameObject.transform.position = playerMovement.startingLocation;
            playerMovement.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
