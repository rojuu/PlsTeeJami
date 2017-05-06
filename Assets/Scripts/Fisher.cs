using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{
    public GameObject arrowPrefab;
    
    private ParticleSystem particleEffect;
	
    void Start()
    {
        particleEffect = GetComponentInChildren<ParticleSystem>();
    }
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.GM.shooting)
        {
            Vector2 arrowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 arrowPos = new Vector2(Input.mousePosition., Input.mousePosition.y - 10);
            Instantiate(arrowPrefab, new Vector2(arrowPos.x, 0.9f), Quaternion.identity);
            //Death();
        }
    }

    private void Death()
    {
        particleEffect.Emit(particleEffect.main.maxParticles);
        GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
