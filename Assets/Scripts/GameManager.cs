﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public List<GameObject> fishPrefabs;
    public GameObject shipPrefab;
    public Transform startPos;
    public Texture2D cursorTexture;
    public Text mistakes;
    public Text pointsText;
    public MonitorScreen monitorScreen;
    public bool shooting;

    private float timer;
    private float nextSpawn;
    private int _mistakes;
    public int Mistakes
    {
        get { return _mistakes; }
        set
        {
            _mistakes = value;
            if (_mistakes >= 3)
                GameOver();
            mistakes.text = "Mistakes : " + _mistakes;
        }
    }
    private int _points;
    public int Points { get { return _points; } set { _points = value;  pointsText.text = "Points : " + _points; } }

    private void Awake()
    {
        if (GM == null)
            GM = this;
        else if (GM != this)
            Destroy(gameObject);

        nextSpawn = Random.Range(12f, 20f);

        GameObject permitOnScreen = GameObject.Find("ScreenPermit");
        monitorScreen = permitOnScreen.GetComponent<MonitorScreen>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > nextSpawn)
        {
            Instantiate(shipPrefab, startPos.position, Quaternion.identity);
            nextSpawn = Random.Range(12f, 20f);
            timer = 0f;
        }
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
