using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float speed = 2f;
    public float jumpForce = 5f;
    float runAwayTime = 1.5f;
    public Transform player;
    private Rigidbody2D rb;
    public Transform lCheck;
    public Transform rCheck;
    public Transform groundCheck;
    private bool isGrounded;
    public LayerMask groundLayer;
    public gameManager gameManager;
    bool running = false;
    float timer = 0f;

    int lit = 0;
    public float health = 3;
    public float damageStreak = 0f;

    public Light hurtLight;

    // Start is called before the first frame update
    void Start()
    {
        lit = 0;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameManager>();
        hurtLight = gameObject.GetComponentInChildren<Light>();
    }
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "Player"){
            gameManager.takeDamage();
            running = true;
            timer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if(IsTouchingWall() && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(!running && lit == 0){
            if(player.transform.position.x < transform.position.x){
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            } else{
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            var step = speed * Time.deltaTime;
            Vector2 moveTo = new Vector2(transform.position.x, 10);
            transform.position = Vector2.MoveTowards(transform.position, moveTo, step);
        } else if(running){
            if(timer < runAwayTime){
                if(player.transform.position.x < transform.position.x){
                    transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                    rb.velocity = new Vector2(speed * 3, rb.velocity.y);
                } else{
                    transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                    rb.velocity = new Vector2(-speed * 3, rb.velocity.y);
                }
            } else{
                running = false;
            }
            timer += Time.deltaTime;
        }
        else
        {
            if (player.transform.position.x < transform.position.x)
            {
                if (damageStreak > 0.1f)
                {
                    transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                }
                rb.velocity = new Vector2(speed * 1.5f * damageStreak, rb.velocity.y);
            }
            else
            {
                if (damageStreak > 0.1f)
                {
                    transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                }
                rb.velocity = new Vector2(-speed * 1.5f * damageStreak, rb.velocity.y);
            }
        }

        if (lit > 0)
        {
            if (health > 0.0f)
            {
                takeDamage();
            }
            else
            {
                Destroy(gameObject);
            }
            hurtLight.intensity = damageStreak * 2;
        }
    }

    bool IsTouchingWall() {
        return  Physics2D.OverlapCircle(lCheck.position, 0.1f, groundLayer) ||
                Physics2D.OverlapCircle(rCheck.position, 0.1f, groundLayer);
    }

    public void lightUp()
    {
        lit++;
    }

    public void lightOff()
    {
        lit--;
        if(lit == 0)
        {
            if (damageStreak > 0.5f)
            {
                running = true;
                timer = 1f;
            }
            damageStreak = 0f;
            hurtLight.intensity = 0f;
        }
    }

    private void takeDamage()
    {
        health -= Time.deltaTime * 0.5f * (1f +(lit/100f));
        damageStreak += Time.deltaTime * 0.5f * (1f + (lit / 100f));
    }
}
