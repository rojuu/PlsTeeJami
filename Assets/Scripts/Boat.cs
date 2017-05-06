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

    private void Start()
    {
        Legal = Random.value > .3f;
        registerNumber = CreateRegisterNumber();

        permit = new Permit(this);

        print(Legal + " : " + permit.isLegal);
        print(registerNumber + " : " + permit.registerNumber);
        print(permit.expirationDate.Day + "." + permit.expirationDate.Month + "." + permit.expirationDate.Year);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
}
