using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float speed = 2f;
    public Transform player;
    private Rigidbody2D rb;
    public Transform wallCheckL;
    public Transform wallCheckR;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "Player"){
            float timer = 0;
            Debug.Log("Hurt player");
            while(timer < 3){
                if(player.transform.position.x < transform.position.x){
                    rb.velocity = new Vector2(speed * 5, rb.velocity.y);
                } else{
                    rb.velocity = new Vector2(-speed * 5, rb.velocity.y);
                }
                timer += Time.deltaTime;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }

}
