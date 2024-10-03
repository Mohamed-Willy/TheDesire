using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    [SerializeField] RoomOneManger manger;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] Material newMaterial;
    [SerializeField] VisualEffect vfx;
    [SerializeField] float duration = 10;
    Material material;
    Transform m_Transform;
    Rigidbody m_Rigidbody;
    bool isMoving;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        material.SetFloat("_Dissolve_Val", -0.5f);
        m_Transform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();

        isMoving = true;
        StartCoroutine(Move());
    }
    public IEnumerator Move()
    {
        while (isMoving)
        {
            yield return null;
            m_Transform.Translate(direction * speed);
            m_Transform.localScale = Vector3.Lerp(m_Transform.localScale, new(2, 2, 2), 0.005f);
        }
        float dissolveIncrement = 0.01f;
        float dissolveTimeStep = duration / (1.5f / dissolveIncrement);
        float currentDissolveValue = -0.5f;

        vfx.SetFloat("Duration", duration/1.25f);
        vfx.Play();
        for (float t = 0; t < duration; t += dissolveTimeStep)
        {
            currentDissolveValue += dissolveIncrement;
            material.SetFloat("_Dissolve_Val", currentDissolveValue);
            if (currentDissolveValue >= 1) break;
            yield return new WaitForSeconds(dissolveTimeStep);
        }

        material.SetFloat("_Dissolve_Val", -0.5f);
        Cannon.canShoot = true;
        manger.TakeEnergy();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NuclearOven"))
        {
            isMoving = false;
        }
        if (other.gameObject.CompareTag("Gate") && isMoving)
        {
            StopAllCoroutines();
            GetComponent<Renderer>().material = newMaterial;
            Cannon.canShoot = true;
            m_Rigidbody.isKinematic = false;
            m_Rigidbody.AddForce(-direction);
            GetComponent<SphereCollider>().isTrigger = false;
        }
    }
}
