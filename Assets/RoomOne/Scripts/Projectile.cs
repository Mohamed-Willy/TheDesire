using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    [SerializeField] RoomOneManger manger;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] Material material;
    [SerializeField] VisualEffect vfx;
    [SerializeField] float duration = 10;
    Transform m_Transform;
    Rigidbody m_Rigidbody;
    bool isMoving;
    private void Start()
    {
        material.SetFloat("_Dissolve_Val", 0.5f);
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
        float dissolveTimeStep = duration * dissolveIncrement;
        float currentDissolveValue = 0.5f;

        vfx.SetFloat("Duration", duration / 2.5f);
        vfx.Play();
        for (float t = 0; t < duration; t += dissolveTimeStep)
        {
            
            currentDissolveValue += dissolveIncrement;
            material.SetFloat("_Dissolve_Val", currentDissolveValue);
            if (currentDissolveValue >= 1) break;
            yield return new WaitForSeconds(dissolveTimeStep);
        }

        material.SetFloat("_Dissolve_Val", 0.5f);
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
            m_Rigidbody.isKinematic = false;
            m_Rigidbody.AddForce(-direction);
            GetComponent<SphereCollider>().isTrigger = false;
        }
    }
}
