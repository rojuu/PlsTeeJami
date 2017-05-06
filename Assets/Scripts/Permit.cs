using UnityEngine;
using System;
using System.Collections.Generic;

public class Permit
{
    public string owner;
    public string registerNumber;
    public DateTime expirationDate;
    public List<Fish> allowedFishes;

    private Boat boat;   

    public Permit (Boat boat)
    {
        this.boat = boat;
        GeneratePermit();
    }

    private void GeneratePermit()
    {

    }
}
