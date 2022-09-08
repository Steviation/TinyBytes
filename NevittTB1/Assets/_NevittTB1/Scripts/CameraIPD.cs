using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIPD : MonoBehaviour
{
    public GameObject LeftEye;
    public GameObject RightEye;
    public float IPD = 64.1f; // In mm

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Convert mm to m with equal offset
        float dist = IPD / 2000.0f;
        // Rig centerpoint

        // Apply to cameras
        LeftEye.transform.localPosition = new Vector3(-dist, 0, 0);
        RightEye.transform.localPosition = new Vector3(dist, 0, 0);
    }
}
