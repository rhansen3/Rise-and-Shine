using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fitToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;
    

        transform.localScale = new Vector3(1,1,1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector2 scale = new Vector2(worldScreenWidth / width, worldScreenHeight / height);
        transform.localScale = scale;
    }
    // Update is called once per frame
}
