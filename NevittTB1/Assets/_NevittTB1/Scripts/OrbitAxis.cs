using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAxis : MonoBehaviour
{
	public GameObject OrbitCenter;
	public float rotationSpeed = 50.0f;
	public float maxRadius = 10.0f;
	private Vector3 center;
	private Vector3 axis;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Get orbit center position
		center = OrbitCenter.transform.position;
		axis = OrbitCenter.transform.up;
		// Rotate around center point
		transform.RotateAround(center, axis, rotationSpeed * Time.deltaTime);
		// Clamp to maximum range from center
		Vector3 offset = transform.position - center;
		transform.position = center + Vector3.ClampMagnitude(offset, maxRadius);
	}
}
