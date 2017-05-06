using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{
    public GameObject arrowPrefab;

    private bool mouseOver;
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
            Instantiate(arrowPrefab, new Vector2(arrowPos.x, arrowPos.y - 2), Quaternion.identity);
            //Death();
        }
    }

    void OnMouseEnter()
    {
        mouseOver = true;
    }
    void OnMouseExit()
    {
        mouseOver = false;
    }

    private void Death()
    {
        particleEffect.Emit(particleEffect.main.maxParticles);
        GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
    }
}
