using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPosition : MonoBehaviour
{
    public Transform targetPos;
    public Image table;
    public Texture2D cursorTexture;
    public float cameraHorizontalSpeed;

    private bool zoomed, shooting;
    
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
        if (shooting)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShootMode(false);
            }
        }
    }

	public void CameraZoom()
    {
        Vector3 zoomPos = new Vector3(targetPos.position.x, targetPos.position.y, -10);
        zoomed = true;
        table.gameObject.SetActive(false);
        transform.position = zoomPos;
    }
    private void CameraReturn()
    {
        zoomed = false;
        table.gameObject.SetActive(true);
        transform.position = new Vector3(0, 0, -10);
    }
    public void ShootMode(bool on)
    {
        if (on)
        {
            shooting = true;
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            shooting = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
