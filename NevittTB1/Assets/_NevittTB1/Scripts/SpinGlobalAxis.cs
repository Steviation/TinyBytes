using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGlobalAxis : MonoBehaviour
{
    public Vector3 SpinAxis;
    public float SpinSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate globally around specified axis
        transform.Rotate(SpinAxis, Time.deltaTime * SpinSpeed, Space.World);
    }
}
