using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * 3.6f;
    }
	void Update ()
    {
        transform.localScale -= new Vector3(0.0005f, 0.007f, 0);
        if (transform.localScale.y <= 0)
            Destroy(gameObject);

        if (rb.velocity.y > 0)
            rb.velocity -= new Vector2(0, 0.05f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fisher")
        {
            col.gameObject.SendMessage("Death");
            Destroy(gameObject);
        }

    }
}
