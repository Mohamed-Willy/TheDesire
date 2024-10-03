using UnityEngine;
public class CustomGravityObject : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] Vector3 customGravity;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidBody.AddForce(customGravity, ForceMode.Acceleration);
    }
}
