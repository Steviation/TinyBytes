using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePan : MonoBehaviour
{
    public float scrollX = 0.1f;
    public float scrollY = 0.1f;
    private Renderer rend;
    //private float offsetX;
    //private float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
