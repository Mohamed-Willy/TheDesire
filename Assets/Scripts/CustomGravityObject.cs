using UnityEngine;
public class CustomGravityObject : MonoBehaviour
{
    Rigidbody rigidBody;
    public Vector3 customGravity;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidBody.AddForce(customGravity, ForceMode.Acceleration);
    }
}
