using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorScreen : MonoBehaviour {

    public Image[] fishImages;

    public void SetPermitObjects(Permit boatPermit)
    {
        Text[] permitTexts = GetComponentsInChildren<Text>();
        permitTexts[0].text = boatPermit.registerNumber;
        permitTexts[1].text = boatPermit.expirationDate.Day + "." + boatPermit.expirationDate.Month + "." + boatPermit.expirationDate.Year;
        permitTexts[2].text = boatPermit.owner;
        for (int i = 0; i < boatPermit.allowedFishes.Count; i++)
        {
            permitTexts[3 + i].text = boatPermit.allowedFishes[i].name;
        }

        for (int i = 0; i < 4; i++)
        {
            fishImages[i].enabled = true;
            fishImages[i].sprite = boatPermit.allowedFishes[i].GetComponent<SpriteRenderer>().sprite;
            fishImages[i].color = boatPermit.allowedFishes[i].GetComponent<SpriteRenderer>().color;
        }
    }
}
