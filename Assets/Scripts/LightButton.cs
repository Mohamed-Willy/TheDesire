using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightButton : MonoBehaviour
{
    [SerializeField] LightManger manger;
    [SerializeField] Vector3Bool RGB;
    [SerializeField] Material material;
    XRSimpleInteractable interactable;
    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(ButtonPressed);
    }
    void ButtonPressed(SelectEnterEventArgs args)
    {
        material.SetFloat("_ExposureWeight", 1 - material.GetFloat("_ExposureWeight"));
        manger.SetColor(RGB);
    }
}
