using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class IronSlatesPuzzelLogic : MonoBehaviour
{
    bool isLatched = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LatchColider"))
        {
            isLatched = true;
            Destroy(GetComponent<XRGrabInteractable>());
            Destroy(GetComponent<Rigidbody>());
            transform.SetPositionAndRotation(other.GetComponent<LatchColider>().positions[0], Quaternion.Euler(other.GetComponent<LatchColider>().rotation[0]));
            other.GetComponent<LatchColider>().positions.RemoveAt(0);
            other.GetComponent<LatchColider>().rotation.RemoveAt(0);
            if (other.GetComponent<LatchColider>().positions.Count <= 0) SceneManager.LoadScene("IntroRoom");
        }
    }
}