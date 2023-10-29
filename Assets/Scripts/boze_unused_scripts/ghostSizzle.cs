using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSizzle : MonoBehaviour
{
    public Transform flashlightOrigin;
    public LayerMask ghostLayer;
    private AudioSource sizzleAudio;
    // Start is called before the first frame update
    void Start()
    {
        sizzleAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(flashlightOrigin.position, flashlightOrigin.up, Mathf.Infinity, ghostLayer);

        if (hit.collider != null && hit.collider.gameObject == gameObject && !sizzleAudio.isPlaying)
        {
            sizzleAudio.Play();
        }
        else if ((hit.collider == null || hit.collider.gameObject != gameObject) && sizzleAudio.isPlaying)
        {
            sizzleAudio.Stop();
        }
    }
}
