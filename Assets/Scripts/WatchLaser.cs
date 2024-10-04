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
            // if (hit.collider)
            // {
            // }
            Debug.Log("Hit something which is: " + hit.transform.name);
        }
        // else lineRenderer.SetPosition(1, transform.forward*1000);
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }
}
