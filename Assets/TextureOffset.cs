using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffset : MonoBehaviour {

    public float scrollSpeed = 1;

    new MeshRenderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update ()
    {
        renderer.material.mainTextureOffset = new Vector2((Time.time * scrollSpeed) % 1, 0);
	}
}
