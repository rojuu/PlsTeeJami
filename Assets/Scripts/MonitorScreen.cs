using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorScreen : MonoBehaviour {
    
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetPermitObjects(Permit boatPermit)
    {
        Text[] permitTexts = GetComponentsInChildren<Text>();
        permitTexts[0].text = boatPermit.registerNumber;
        permitTexts[1].text = boatPermit.expirationDate.ToString();
        permitTexts[2].text = boatPermit.owner;
        for (int i = 0; i < boatPermit.allowedFishes.Count; i++)
        {
            permitTexts[3 + i].text = boatPermit.allowedFishes[i].name;
        }
    }
}
