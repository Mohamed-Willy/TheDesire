using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    Transform m_Transform;
    bool isMoving;
    [SerializeField] Material material;
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
        for (int i = 0; i < 100; i++)
        {
            material.SetFloat("_Dissolve_Val", material.GetFloat("_Dissolve_Val") + 0.01f);
            yield return new WaitForSeconds(0.1f);
        }
        material.SetFloat("_Dissolve_Val", -0.5f);
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
