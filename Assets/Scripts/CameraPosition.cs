using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPosition : MonoBehaviour
{
    public Transform targetPos;
    public Image table, zoomOverlay;
    public float cameraHorizontalSpeed;

    private bool zoomed;
    
    void Start ()
    {
        cameraHorizontalSpeed = 5f;
    }
    void Update ()
    {
        if (zoomed)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CameraReturn();
            }
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * cameraHorizontalSpeed, 0));
            }
        }
        if (GameManager.GM.shooting)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.GM.ShootMode(false);
            }
        }
    }

	public void CameraZoom()
    {
        if (GameManager.GM.shooting)
            GameManager.GM.ShootMode(false);

        Vector3 zoomPos = new Vector3(targetPos.position.x, targetPos.position.y, -10);
        zoomed = true;
        table.gameObject.SetActive(false);
        zoomOverlay.gameObject.SetActive(true);
        transform.position = zoomPos;
    }
    private void CameraReturn()
    {
        zoomed = false;
        zoomOverlay.gameObject.SetActive(false);
        table.gameObject.SetActive(true);
        transform.position = new Vector3(0, 0, -10);
    }
}
