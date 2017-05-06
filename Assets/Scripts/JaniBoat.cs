using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaniBoat : MonoBehaviour
{
    private bool mouseOver;
    private MonitorScreen monitorScreen;
    private Boat boat; // zoomed boat

    public GameObject screenPermit;

    void Start ()
    {
        monitorScreen = screenPermit.GetComponent<MonitorScreen>();
        boat = GameObject.Find("BigBoat").GetComponent<Boat>();
    }
	void Update ()
    {
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
