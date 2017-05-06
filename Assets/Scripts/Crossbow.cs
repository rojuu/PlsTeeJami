using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crossbow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Sprite ready, unReady;

    private bool isReady;
    private float shootTime, shootTimer;
    
    void Start ()
    {
        isReady = true;
        shootTime = 1.5f;
        shootTimer = shootTime;
    }
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.GM.shooting && isReady)
        {
            Vector2 arrowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(arrowPrefab, new Vector2(arrowPos.x, 0.9f), Quaternion.identity);
            isReady = false;
            GetComponent<Image>().sprite = unReady;
        }
        if (!isReady)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                isReady = true;
                shootTimer = shootTime;
                GetComponent<Image>().sprite = ready;
            }
        }
    }
    
}
