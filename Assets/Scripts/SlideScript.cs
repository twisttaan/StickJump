using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideScript : MonoBehaviour
{
    public Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2D.velocity = new Vector2(-4, 0);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
