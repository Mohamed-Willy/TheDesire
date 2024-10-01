using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Dissolve_Demo : MonoBehaviour
{
    Material material;
    [SerializeField] VisualEffect vfx;
    [SerializeField] float duration = 10;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        material.SetFloat("_Dissolve_Val", -0.5f);

        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);
        // Play VFX
        vfx.SetFloat("Duration", duration);
        vfx.Play();

        float dissolveIncrement = 0.01f;
        float dissolveTimeStep = duration / (1.5f / dissolveIncrement);
        float currentDissolveValue = material.GetFloat("_Dissolve_Val");

        for (float t = 0; t <= duration; t += dissolveTimeStep)
        {
            currentDissolveValue += dissolveIncrement;
            material.SetFloat("_Dissolve_Val", currentDissolveValue);
            yield return new WaitForSeconds(dissolveTimeStep);
        }

        material.SetFloat("_Dissolve_Val", -0.5f);
        // yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
