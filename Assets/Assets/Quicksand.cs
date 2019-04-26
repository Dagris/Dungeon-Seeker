using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksand : MonoBehaviour
{
    public Renderer renderer;
    public float scrollX;
    public float scrollY;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        float OffsetX = Time.time * scrollX;
        float OffsetY = Time.time * scrollY;
        renderer.material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
