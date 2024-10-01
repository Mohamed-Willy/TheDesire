using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RoomOneManger : MonoBehaviour
{
    int energyTaken;
    [SerializeField] List<LightButton> lightBTNs;
    private void Start()
    {
        energyTaken = 0;
        foreach (var button in lightBTNs)
        {
            button.GetComponent<XRSimpleInteractable>().enabled = false;
        }
    }
    public void TakeEnergy()
    {
        energyTaken++;
        Debug.Log(energyTaken);
        if(energyTaken >= 3)
        {
            foreach (var button in lightBTNs)
            {
                button.GetComponent<XRSimpleInteractable>().enabled = true;
                button.ButtonPressed(null);
            }
        }
    }
}
