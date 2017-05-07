using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaniBoat : MonoBehaviour
{
    public float speed;

    private GameObject permitOnScreen;
    private bool mouseOver;
    //private MonitorScreen monitorScreen;
    private Boat boat; // zoomed boat

    void Awake ()
    {
        boat = GetComponentInParent<Boat>();
    }
	void Update ()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (Input.GetMouseButtonDown(0) && mouseOver)
        {
            GameManager.GM.monitorScreen.SetPermitObjects(boat.permit);
            //permitOnScreen.SetActive(true);
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
}
