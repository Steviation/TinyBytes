using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShift : MonoBehaviour
{
	public float HueSpeed = 0.1f;
	private Renderer rend;
	private float h, s, v;
	private float offset;

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
		offset += Time.deltaTime * HueSpeed;
		// Convert HSV to RGB
		Color col = Color.HSVToRGB(Mathf.Repeat(h + offset,1), s, v);
		// Set material color
		rend.material.color = col;
	}
}
