using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHandleController : MonoBehaviour
{
    public bool isLeftHandle; // Is this the left handle?
    public float weightChangeAmount = 1f; // How much weight is changed per click
    public bool changedAlready = false;

    // Method triggered when the handle is clicked
    //TODO:Add increasing and decreasing the weight inside this event
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     // Toggle between increasing and decreasing the weight
    //     bool isDecreasing = eventData.button == PointerEventData.InputButton.Right; // Right-click to decrease

    //     float weightChange = isDecreasing ? -weightChangeAmount : weightChangeAmount;
    //     ScaleManager.Instance.ModifyWeight(isLeftHandle, weightChange);
    // }

    public void OnControllerClicked (bool increase) {
        if (changedAlready)
        {
            return;
        }
        changedAlready = true;
        ScaleManager.Instance.ModifyWeight(isLeftHandle, increase == true ? weightChangeAmount : -weightChangeAmount);
        ScaleManager.Instance.ModifyWeight(!isLeftHandle, increase == false ? weightChangeAmount*2 : -weightChangeAmount*2);
        StartCoroutine(EndingNow());
    }

    IEnumerator EndingNow()
    {
        yield return new WaitForSeconds(0.5f);
        changedAlready = false;
    }
}
