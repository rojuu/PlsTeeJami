using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public bool Legal { get; private set; }

    public Permit permit;

    public List<Fish> fishes;
    public string registerNumber;
    

    private void Start()
    {
        Legal = Random.value > .3f;
        permit = new Permit(this);
    }
}
