using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAudionControl : MonoBehaviour
{

    public Transform playerTransform;
    public float cutoffDistance = 10f;
    private AudioSource enemyAudio;
    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        
        if (distanceToPlayer > cutoffDistance)
        {
            enemyAudio.mute = true;
        }
        else
        {
            enemyAudio.mute = false;
        }
    }
}
