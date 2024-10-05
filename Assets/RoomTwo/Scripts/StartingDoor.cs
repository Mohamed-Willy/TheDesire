using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDoor : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool isLast = false;
    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            if (isLast) {
                anim.SetTrigger("OpenTheFkinDoor");
            } else {
                anim.enabled = true;
                anim.Rebind();
                anim.Play(0, -1, 0);
            }
        }
    }
}
