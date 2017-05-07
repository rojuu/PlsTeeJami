using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPosition : MonoBehaviour
{
    public Transform targetPos, startPos, endPos;
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
            if (Input.GetAxisRaw("Horizontal") < 0 && transform.position.x > startPos.position.x + 12f)
            {
                transform.Translate(Vector2.left * Time.deltaTime * cameraHorizontalSpeed, 0);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && transform.position.x < endPos.position.x - 12f)
            {
                transform.Translate(Vector2.right * Time.deltaTime * cameraHorizontalSpeed, 0);
            }
        }
        if (GameManager.GM.shooting)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
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
