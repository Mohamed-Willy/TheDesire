using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMainMenu : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] AnimateHandOnInput leftHand;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, new Vector3(0,0,1) * 10f);
        if (Physics.Raycast(transform.position, transform.forward * 10f, out hit))
        {
            // if the player pressed whatever button does within the functionality of the VR
            //TODO: Write if condition here
            // Invert the gravity
            if (hit.collider.GetComponent<Animator>() != null ) {
                hit.collider.GetComponent<Animator>().enabled = true;
            }
            if (leftHand.triggerValue > 0) {
                // Puzzle 1 interaction
                if (hit.collider.GetComponent<CapsuleButton>() != null) {
                    if (hit.collider.GetComponent<CapsuleButton>().start == true) {
                        hit.collider.GetComponent<CapsuleButton>().StartLevel();
                        AudioManager.Instance.playSFX(AudioManager.Instance.buttonClickMainMenu);
                    } else {
                        AudioManager.Instance.playSFX(AudioManager.Instance.buttonClickMainMenu);
                        hit.collider.GetComponent<CapsuleButton>().ExitGame();
                    }
                }

                leftHand.triggerValue = 0;
            }
        }
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }
}
