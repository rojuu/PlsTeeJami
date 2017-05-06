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
    private string[] firstNames = { "Harold", "Malcolm", "Drew", "Ferdinand", "Efrain", "Hunter", "Monroe", "Herschel", "Ronny", "Dante", "Cole", "Winfred", "Dario", "Roland"  };
    private string[] lastNames = { "Crispin", "Maize", "Quintal", "Trottier", "Collier", "Kromer", "Zane", "Neth", "Velazquez", "Torbett", "Rocamora", "Irvine", "Thiel", "Clouse", "Mathewson", "Feller", "Sorrentino", "Railsback", "Tew", "Mickelson "};

    public Permit (Boat boat)
    {
        this.boat = boat;
        GeneratePermit();
    }

    private void GeneratePermit()
    {
        owner = firstNames[UnityEngine.Random.Range(0, firstNames.Length)] + " " + lastNames[UnityEngine.Random.Range(0, lastNames.Length)];
        registerNumber = boat.registerNumber;

        if (!boat.Legal && UnityEngine.Random.value >= .5f)
        {
            //int index = UnityEngine.Random.Range(1, registerNumber.Length);
            //registerNumber = registerNumber.Replace(registerNumber[0], registerNumber[index]);

            registerNumber = RandomizeString(registerNumber);

            expirationDate = DateTime.Today.AddDays(UnityEngine.Random.Range(-100, -10));
            isLegal = false;
        }
        else
        {
            expirationDate = DateTime.Today.AddDays(UnityEngine.Random.Range(20, 100)).AddMonths(2);
            isLegal = true;
        }

        allowedFishes = new List<GameObject>();

        while (allowedFishes.Count < 4)
        {
            GameObject fish = GameManager.GM.fishPrefabs[UnityEngine.Random.Range(0, GameManager.GM.fishPrefabs.Count)];
            if (!allowedFishes.Contains(fish))
                allowedFishes.Add(fish);
        }
    }

    private string RandomizeString(string s)
    {
        char[] chars = s.ToCharArray();
        char[] alphNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            if (i % 2 == 1 && UnityEngine.Random.value < .5f)
            {
                chars[i] = alphNum[UnityEngine.Random.Range(0, alphNum.Length)];
            }
        }
        return new string(chars);
    }

}

