using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public bool Legal { get; private set; }

    public Permit permit;

    public List<Fish> fishes;
    public string registerNumber;
    
    [SerializeField] private float speed;
    private Transform startPoint, endPoint;
    private bool passed;

    private void Start()
    {
        Legal = Random.value > .3f;
        registerNumber = CreateRegisterNumber();

        permit = new Permit(this);

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
        char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        string number = "";
        for (int i = 0; i < 5; i++)
        {
            number += characters[Random.Range(0, characters.Length)];
        }
        return number;
    }
    private void BoatPassCheck()
    {
        passed = true;

        if (!Legal || !permit.isLegal)
            GameManager.GM.Mistakes++;

        print(GameManager.GM.Mistakes);
        gameObject.SetActive(false);
    }
}
