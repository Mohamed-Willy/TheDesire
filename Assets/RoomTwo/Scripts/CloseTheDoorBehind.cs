using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseTheDoorBehind : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool isLast = false;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {

            if (isLast == true) {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            } else {
                anim.SetTrigger("CloseTheDoor");
                anim.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
