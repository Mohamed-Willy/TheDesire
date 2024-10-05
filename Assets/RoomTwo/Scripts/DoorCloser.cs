using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCloser : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Close");
        }
    }
}
