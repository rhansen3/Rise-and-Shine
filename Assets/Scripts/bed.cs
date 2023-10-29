using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    gameManager gameManager;
    public Sprite withCup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<SpriteRenderer>().sprite == withCup){
            gameManager.win();
        }   
    }
}
