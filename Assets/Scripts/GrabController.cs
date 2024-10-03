using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabController : MonoBehaviour
{
    [SerializeField] UnityEvent OnGrab;
    [SerializeField] UnityEvent OnLeft;
    XRGrabInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrabFn);
        interactable.selectExited.AddListener(OnLeftFn);
    }
    void OnGrabFn(SelectEnterEventArgs arg)
    {
        OnGrab.Invoke();
    }
    void OnLeftFn(SelectExitEventArgs arg)
    {
        OnLeft.Invoke();
    }
}
