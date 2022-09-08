using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShift : MonoBehaviour
{
	public float HueSpeed = 0.1f;
	private Renderer rend;
	//private Material mat;
	private float h, s, v;
	//private float offset;

	// Start is called before the first frame update
	void Start()
	{
		// Get renderer of attached gameobject
		rend = GetComponent<Renderer>();
		// Get assigned material
		Material mat = rend.material;
		// Extract and convert RGB to HSV
		Color.RGBToHSV(mat.GetColor("_Color"), out h, out s, out v);
	}

	// Update is called once per frame
	void Update()
	{
		float r, g, b;
		float offset = Time.time * HueSpeed;
		// Convert HSV to RGB
		Color col = Color.HSVToRGB((h + offset) % 1f, s, v);
		// Set material color
		rend.material.color = col;
	}
}
