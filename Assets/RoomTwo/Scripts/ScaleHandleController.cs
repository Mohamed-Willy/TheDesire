using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHandleController : MonoBehaviour
{
    public bool isLeftHandle; // Is this the left handle?
    public float weightChangeAmount = 1f; // How much weight is changed per click

    // Method triggered when the handle is clicked
    //TODO:Add increasing and decreasing the weight inside this event
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     // Toggle between increasing and decreasing the weight
    //     bool isDecreasing = eventData.button == PointerEventData.InputButton.Right; // Right-click to decrease

    //     float weightChange = isDecreasing ? -weightChangeAmount : weightChangeAmount;
    //     ScaleManager.Instance.ModifyWeight(isLeftHandle, weightChange);
    // }
}
