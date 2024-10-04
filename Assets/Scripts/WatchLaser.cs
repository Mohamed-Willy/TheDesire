using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class WatchLaser : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 laserStartPosition;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        laserStartPosition = lineRenderer.GetPosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, new Vector3(0,0,5) * 10f);
        if (Physics.Raycast(transform.position, transform.forward * 10, out hit))
        {
            // if the player pressed whatever button does within the functionality of the VR
            //TODO: Write if condition here
            // Invert the gravity
            if (hit.collider.GetComponent<GravityInverter>() != null) {
                hit.collider.GetComponent<GravityInverter>().InvertGravity();
            }
        }
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }
}
