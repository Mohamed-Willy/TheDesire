using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GhostPreviewSwitch : MonoBehaviour
{
    Volume volume;
    [SerializeField] VolumeProfile ghostProfile;

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
    }

    public void SwitchGhostView () {
        volume.profile = ghostProfile;
    }
}
