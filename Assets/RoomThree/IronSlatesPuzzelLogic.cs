using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IronSlatesPuzzelLogic : MonoBehaviour
{
    bool isLatched = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LatchColider"))
        {
            Latch(other.gameObject);
        }
    }
    void Latch(GameObject other)
    {
        if (isLatched) return;
        Destroy(other);
        isLatched = true;
        GetComponent<XRGrabInteractable>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        transform.SetPositionAndRotation(other.GetComponent<LatchColider>().positions[0], Quaternion.Euler(other.GetComponent<LatchColider>().rotation[0]));
        other.GetComponent<LatchColider>().positions.RemoveAt(0);
        other.GetComponent<LatchColider>().rotation.RemoveAt(0);
    }
}