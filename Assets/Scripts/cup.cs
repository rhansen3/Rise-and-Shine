using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    public SpriteRenderer player;
    public Sprite withCup;
    public Sprite withoutCup;
    // Start is called before the first frame update
    void Start()
    {
        player.sprite = withoutCup;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            player.sprite = withCup;
            GetComponent<SpriteRenderer>().enabled = false;
        }   
    }
}
