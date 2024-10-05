using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] GhostPreviewSwitch ghostPreviewSwitch;
    [SerializeField] GameObject deathCamera;
    
    public void StartEvent () {
        deathCamera.SetActive(true);
        ghostPreviewSwitch.SwitchGhostView();
    }
}
