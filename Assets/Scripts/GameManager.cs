using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public List<GameObject> fishPrefabs;
    public Texture2D cursorTexture;
    public bool shooting;

    private int _mistakes;
    public int Mistakes
    {
        get { return _mistakes; }
        set
        {
            _mistakes = value;
            if (_mistakes >= 3)
                GameOver();
        }
    }
    
    private void Awake()
    {
        if (GM == null)
            GM = this;
        else if (GM != this)
            Destroy(gameObject);
    }

    private void GameOver()
    {
        print("Game Over");
    }

    public void ShootMode(bool on)
    {
        if (on)
        {
            shooting = true;
            Vector2 crosshairPos = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
            Cursor.SetCursor(cursorTexture, crosshairPos, CursorMode.Auto);
        }
        else
        {
            shooting = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
