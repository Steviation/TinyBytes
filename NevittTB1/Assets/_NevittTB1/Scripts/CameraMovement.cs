using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float cameraSpeed = 0.1f;
	public float mouseSensitivity = 1.0f;
	public float arrowsSensitivity = 1.0f;
	public float maxYAngle = 80f;
	private bool cursorLock = false;
	private Vector2 currentRotation;
	// Start is called before the first frame update
	void Start()
	{
		// Get initial camera rotation
		Vector3 initRotation = transform.rotation.eulerAngles;
		currentRotation = new Vector2(initRotation.y,initRotation.x);
		// Clamp rotation
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
		// Transform camera
		transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
	}

	// Update is called once per frame
	void Update()
	{ 
		// WASD keyboard input
		// Move forward
		if(Input.GetKey(KeyCode.W)) 
		{
			transform.Translate(0, 0, cameraSpeed);
		}
		// Move backward
		if (Input.GetKey(KeyCode.S)) 
		{
			transform.Translate(0, 0, -cameraSpeed);
		}
		// Move left
		if (Input.GetKey(KeyCode.A)) 
		{
			transform.Translate(-cameraSpeed, 0, 0);
		}
		// Move right
		if (Input.GetKey(KeyCode.D)) 
		{
			transform.Translate(cameraSpeed, 0, 0);
		}
		// Move up
		if (Input.GetKey(KeyCode.E)) 
		{
			transform.Translate(0, cameraSpeed, 0);
		}
		// Move down
		if (Input.GetKey(KeyCode.Q)) 
		{
			transform.Translate(0, -cameraSpeed, 0);
		}

		// cursorLock update
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			cursorLock = !cursorLock;
		}
		// Mouse rotation
		if (cursorLock)
		{
			// Get mouse movement
			currentRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
			currentRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
			// Clamp rotation values
			currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
			currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
			// Transform camera
			transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
			// Lock mouse
			Cursor.lockState = CursorLockMode.Locked;
		}
		// Use arrow keys
		else
		{
			// Rotate up
			if (Input.GetKey(KeyCode.UpArrow))
			{
				// Evaluate rotation
				currentRotation.y -= arrowsSensitivity;
				// Clamp rotation
				currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
				
			}
			// Rotate down
			if (Input.GetKey(KeyCode.DownArrow))
			{
				// Evaluate rotation
				currentRotation.y += arrowsSensitivity;
				// Clamp rotation
				currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
			}
			// Rotate left
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				// Evaluate rotation
				currentRotation.x -= arrowsSensitivity;
				// Clamp rotation
				currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
			}
			// Rotate right
			if (Input.GetKey(KeyCode.RightArrow))
			{
				// Evaluate rotation
				currentRotation.x += arrowsSensitivity;
				// Clamp rotation
				currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
			}
			// Apply rotation
			transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
			// Unlock mouse
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
