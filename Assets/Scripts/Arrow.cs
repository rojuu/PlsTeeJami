using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up;
        StartCoroutine("Lifetime");
    }
	void Update ()
    {
        transform.localScale -= new Vector3(0.0005f, 0.005f, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fisher")
        {
            print("hit fisher");
            col.gameObject.SendMessage("Death");
            Destroy(gameObject);
        }

    }
    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
