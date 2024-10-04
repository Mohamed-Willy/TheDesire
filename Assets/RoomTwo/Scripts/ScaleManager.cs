using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public static ScaleManager Instance;

    // Variables to store weights of both sides
    public float weightLeft = 0f;
    public float weightRight = 0f;

    // Max and Min values for weight
    public float maxWeight = 10f;
    public float minWeight = 0f;

    // Balance variables
    public float balanceTolerance = 0.1f; // How much difference is allowed for the scale to be balanced

    void Awake () {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    void Update()
    {
        // Check if the scale is balanced
        
    }

    // Method to increase/decrease weight
    public void ModifyWeight(bool isLeftHandle, float amount)
    {
        if (isLeftHandle)
        {
            weightLeft = Mathf.Clamp(weightLeft + amount, minWeight, maxWeight); // Update and clamp the left weight
        }
        else
        {
            weightRight = Mathf.Clamp(weightRight + amount, minWeight, maxWeight); // Update and clamp the right weight
        }

        UpdateScale();
    }

    // Check if the scale is balanced
    void CheckBalance()
    {
        float weightDifference = Mathf.Abs(weightLeft - weightRight);

        if (weightDifference <= balanceTolerance)
        {
            Debug.Log("Scale is Balanced!");
            // Add behavior for when the scale is balanced (like showing visual feedback)
        }
        else
        {
            Debug.Log("Scale is Unbalanced");
            // Add behavior for unbalanced state (like tilting the scale)
        }

        CheckBalance();
    }

    // Update the visual representation of the scale
    void UpdateScale()
    {
        // Rotate the scale based on the difference in weights
        float angle = (weightRight - weightLeft) * 10f; // You can adjust this multiplier
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
