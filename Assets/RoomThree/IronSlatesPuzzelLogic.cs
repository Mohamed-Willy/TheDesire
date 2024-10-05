using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSlatesPuzzelLogic : MonoBehaviour
{
    public GameObject objectToAttachTo;

    private bool isLatched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToAttachTo && !isLatched)
        {
            // Set the parent to the object we are attaching to
            transform.SetParent(other.transform);

            // Match the position of the target object but keep the current rotation
            transform.position = other.transform.position;

            Debug.Log($"{gameObject.name} has latched onto {other.gameObject.name}.");

            isLatched = true;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Get the collider and destroy it
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                Destroy(collider);
                Debug.Log($"Collider on {gameObject.name} has been destroyed.");
            }
        }
    }
}
