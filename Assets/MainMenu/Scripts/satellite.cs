using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satellite : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    // private float distanceFromOrigin; 
    public Transform rotatingPivot;

    void Start()
    {
        // distanceFromOrigin = Vector3.Distance(transform.position, Vector3.zero);
    }

    void Update()
    {
        Quaternion originalRotation = transform.rotation;

        transform.RotateAround(rotatingPivot.position, Vector3.up, rotationSpeed * Time.deltaTime);

        transform.rotation = originalRotation;
    }
}
