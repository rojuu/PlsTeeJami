using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;

	void Start ()
    {
        //speed = Random.Range(-0.7f, 0.4f);
	}
	
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}
}
