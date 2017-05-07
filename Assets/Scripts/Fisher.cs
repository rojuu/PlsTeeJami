using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{
    public SpriteRenderer zoomedFisher;
    
    private ParticleSystem particleEffect;
    private Boat boat;

    void Start()
    {
        particleEffect = GetComponentInChildren<ParticleSystem>();
        boat = GetComponentInParent<Boat>();
    }

    private void Death()
    {
        particleEffect.Emit(particleEffect.main.maxParticles);
        GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
        zoomedFisher.enabled = false;
        boat.driverDead = true;
        if (boat.Legal)
            GameManager.GM.Mistakes++;
        else
            GameManager.GM.Points += 10;
    }
}
