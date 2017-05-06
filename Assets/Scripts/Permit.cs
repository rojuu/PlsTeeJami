using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Permit
{
    public string owner;
    public string registerNumber;
    public DateTime expirationDate;
    public List<GameObject> allowedFishes;
    public bool isLegal;

    private Boat boat;

    public Permit (Boat boat)
    {
        this.boat = boat;
        GeneratePermit();
    }

    private void GeneratePermit()
    {
        owner = "Bob Bobbins";
        registerNumber = boat.registerNumber;

        if (!boat.Legal && UnityEngine.Random.value >= .5f)
        {
            int index = UnityEngine.Random.Range(1, registerNumber.Length);
            registerNumber = registerNumber.Replace(registerNumber[0], registerNumber[index]);

            expirationDate = DateTime.Today.AddDays(UnityEngine.Random.Range(-100, -10));
            isLegal = false;
        }
        else
        {
            expirationDate = DateTime.Today.AddDays(UnityEngine.Random.Range(20, 100)).AddMonths(2);
            isLegal = true;
        }

        allowedFishes = new List<GameObject>();

        while (allowedFishes.Count < 5)
        {
            GameObject fish = GameManager.GM.fishPrefabs[UnityEngine.Random.Range(0, GameManager.GM.fishPrefabs.Count)];
            if (!allowedFishes.Contains(fish))
                allowedFishes.Add(fish);
        }
    }

}

