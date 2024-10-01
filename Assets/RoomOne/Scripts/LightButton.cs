using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightButton : MonoBehaviour
{
    [SerializeField] LightManger manger;
    [SerializeField] Vector3Bool RGB;
    [SerializeField] Material material;
    XRSimpleInteractable interactable;
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(ButtonPressed);
        material.SetColor("_EmissiveColor", Color.black);
    }
    public void ButtonPressed(SelectEnterEventArgs args)
    {
        material.SetColor("_EmissiveColor", material.color - material.GetColor("_EmissiveColor"));
        manger.SetColor(RGB);
    }
}
