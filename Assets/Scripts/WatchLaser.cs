using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class WatchLaser : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] AnimateHandOnInput rightHand;
    [SerializeField] AnimateHandOnInput leftHand;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
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
            if (rightHand.triggerValue > 0) {
                // Puzzle 1 interaction
                if (hit.collider.GetComponent<GravityInverter>() != null) {
                    hit.collider.GetComponent<GravityInverter>().InvertGravity();
                }

                // Puzzle 2 interaction
            }
            if (leftHand.triggerValue > 0) {
                // Puzzle 2 Decrease Value
            }
        }
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }
}
