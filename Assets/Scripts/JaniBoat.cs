using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaniBoat : MonoBehaviour
{
    public GameObject screenPermit;

    private bool mouseOver;
    private MonitorScreen monitorScreen;
    private Boat boat; // zoomed boat
    private float startPoint, endPoint;

    void Start ()
    {
        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>().position.x;
        transform.Translate(new Vector2(startPoint, 3.5f));
        endPoint = GameObject.Find("EndPoint").GetComponent<Transform>().position.x;
        monitorScreen = screenPermit.GetComponent<MonitorScreen>();
        boat = GameObject.Find("BigBoat").GetComponent<Boat>();
    }
	void Update ()
    {
        if (transform.position.x < endPoint)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }

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
