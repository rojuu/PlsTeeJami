using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{
    private bool mouseOver;
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && mouseOver && GameManager.GM.shooting)
        {
            Death();
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
        print("DEATH");
        gameObject.SetActive(false);
    }
}
