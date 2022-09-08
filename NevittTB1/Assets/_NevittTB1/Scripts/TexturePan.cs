using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePan : MonoBehaviour
{
	public float scrollX = 0.1f;
	public float scrollY = 0.1f;
	private Renderer rend;
	private float offsetX = 0.0f;
	private float offsetY = 0.0f;

	// Start is called before the first frame update
	void Start()
	{
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update()
	{
		offsetX += Time.deltaTime * scrollX;
		offsetY += Time.deltaTime * scrollY;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
	}
}
