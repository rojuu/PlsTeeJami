using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public bool Legal { get; private set; }

    public Permit permit;

    public List<GameObject> fishes;
    public List<Transform> fishSpawnpoints;
    public string registerNumber;
    public bool driverDead;
    
    [SerializeField] private float speed;

    private Transform startPoint, endPoint;
    private TextMesh textMesh;
    private bool passed;

    private void Start()
    {
        Legal = Random.value > .3f;
        registerNumber = CreateRegisterNumber();
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = registerNumber;
        permit = new Permit(this);
        SpawnFish();

        print(Legal + " : " + permit.isLegal);
        print(registerNumber + " : " + permit.registerNumber);
        print(permit.expirationDate.Day + "." + permit.expirationDate.Month + "." + permit.expirationDate.Year);

        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        endPoint = GameObject.Find("EndPoint").GetComponent<Transform>();
    }

    private void Update()
    {
        if (transform.position.x < endPoint.position.x)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else
        {
            if (!passed)
            {
                BoatPassCheck();
            }
        }
    }

    private string CreateRegisterNumber()
    {
        char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ013456789".ToCharArray();
        string number = "";
        for (int i = 0; i < 6; i++)
        {
            number += characters[Random.Range(0, characters.Length)];
        }
        return number;
    }

    private void BoatPassCheck()
    {
        passed = true;

        if (!Legal && !driverDead)
            GameManager.GM.Mistakes++;
        else
            GameManager.GM.Points += 10;
        print(GameManager.GM.Mistakes);
        gameObject.SetActive(false);
    }

    private void SpawnFish()
    {
        bool hasIllegalFish = false;
        for (int i = 0; i < Random.Range(2, 10); i++)
        {
            GameObject fish;
            if (!Legal && permit.isLegal)
            {
                fish = GameManager.GM.fishPrefabs[Random.Range(0, GameManager.GM.fishPrefabs.Count)];
                if (!permit.allowedFishes.Contains(fish))
                    hasIllegalFish = true;
            }
            else
            {
                fish = permit.allowedFishes[Random.Range(0, permit.allowedFishes.Count)];
            }
            fishes.Add(fish);
        }

        if (!Legal && permit.isLegal && !hasIllegalFish)
        {
            foreach (GameObject g in GameManager.GM.fishPrefabs)
            {
                if (!permit.allowedFishes.Contains(g))
                {
                    fishes[Random.Range(0, fishes.Count)] = g;
                }
            }
        }

        for (int i = 0; i < fishes.Count; i++)
        {
            Instantiate(fishes[i], fishSpawnpoints[i].position, Quaternion.identity, fishSpawnpoints[i]);
        }

    }
}
