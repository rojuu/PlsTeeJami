using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaniBoat : MonoBehaviour
{
    public GameObject screenPermit;
    public float speed;

    private bool mouseOver;
    private MonitorScreen monitorScreen;
    private Boat boat; // zoomed boat

    void Start ()
    {
        monitorScreen = screenPermit.GetComponent<MonitorScreen>();
        boat = GameObject.Find("BigBoat").GetComponent<Boat>();
    }
	void Update ()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (Input.GetMouseButtonDown(0) && mouseOver)
        {
            monitorScreen.SetPermitObjects(boat.permit);
            if (!screenPermit.activeInHierarchy)
            {
                screenPermit.SetActive(true);
            }
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
