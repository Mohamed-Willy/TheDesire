using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public static ScaleManager Instance;

    [SerializeField] GameObject theLights;
    [SerializeField] GameObject doors;
    [SerializeField] GameObject puzzle;

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
            Destroy(gameObject);
    }

    void Start () {
        UpdateScale();
    }

    void Update()
    {
        // Check if the scale is balanced
        
    }

    // Method to increase/decrease weight
    public void ModifyWeight(bool isLeftHandle, float amount)
    {
        if (isLeftHandle)
            weightLeft = Mathf.Clamp(weightLeft + amount, minWeight, maxWeight); // Update and clamp the left weight
        else
            weightRight = Mathf.Clamp(weightRight + amount, minWeight, maxWeight); // Update and clamp the right weight

        UpdateScale();
    }

    // Check if the scale is balanced
    void CheckBalance()
    {
        float weightDifference = Mathf.Abs(weightLeft - weightRight);

        if (weightDifference <= balanceTolerance)
        {
            StartCoroutine(FinishPuzzle());
        }

        //CheckBalance();
    }

    // Update the visual representation of the scale
    void UpdateScale()
    {
        // Rotate the scale based on the difference in weights
        float angle = (weightRight - weightLeft) * 10f; // You can adjust this multiplier
        transform.rotation = Quaternion.Euler(0, 0, angle+180);
        CheckBalance();
    }

    IEnumerator FinishPuzzle () {
        yield return new WaitForSeconds(2f);
        theLights.SetActive(false);
        yield return new WaitForSeconds(2f);
        theLights.SetActive(true);
        doors.GetComponent<Animator>().enabled = true;
        doors.GetComponent<Animator>().SetTrigger("OpenTheDoor");
        //doors.GetComponent<Animator>().Rebind();
        //doors.GetComponent<Animator>().Play(0, -1, 0);
        //TODO:Add moving the player to the right position if possible
        Destroy(puzzle, 0.5f);
    }
}
