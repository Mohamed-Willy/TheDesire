using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    Transform m_Transform;
    bool isMoving;
    [SerializeField] Material material;
    [SerializeField] VisualEffect vfx;
    [SerializeField] float duration = 10;
    private void Start()
    {
        material.SetFloat("_Dissolve_Val", -0.5f);
        m_Transform = transform;
        Launch();
    }
    public void Launch()
    {
        isMoving = true;
        StartCoroutine(Move());
    }
    public IEnumerator Move()
    {
        while (isMoving)
        {
            yield return null;
            m_Transform.Translate(direction * speed);
        }

        // Play VFX
        vfx.SetFloat("Duration", duration/2);
        vfx.Play();

        float dissolveIncrement = 0.01f;
        float dissolveTimeStep = duration / (1f / dissolveIncrement);
        float currentDissolveValue = material.GetFloat("_Dissolve_Val");

        for (float t = 0; t < duration; t += dissolveTimeStep)
        {
            currentDissolveValue += dissolveIncrement;
            material.SetFloat("_Dissolve_Val", currentDissolveValue);
            yield return new WaitForSeconds(dissolveTimeStep);
        }

        material.SetFloat("_Dissolve_Val", -0.5f);
        // yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NuclearOven"))
        {
            isMoving = false;
        }
    }
}
