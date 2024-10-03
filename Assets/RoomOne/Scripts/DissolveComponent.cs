using System.Collections;
using UnityEngine;

public class DissolveComponent : MonoBehaviour
{
    
    Material material;

    private void Start () {
        material = GetComponent<Renderer>().material;
        material.SetFloat("_Dissolve_Val", -0.5f);
    }

    public void PlayDissolve (float duration) {
        StartCoroutine(Dissolve(duration));
    }

    IEnumerator Dissolve (float duration) {
        float dissolveIncrement = 0.01f;
        float dissolveTimeStep = duration / (1.5f / dissolveIncrement);
        float currentDissolveValue = -0.5f;

        for (float t = 0; t < duration; t += dissolveTimeStep)
        {
            currentDissolveValue += dissolveIncrement;
            material.SetFloat("_Dissolve_Val", currentDissolveValue);
            if (currentDissolveValue >= 1) break;
            yield return new WaitForSeconds(dissolveTimeStep);
        }

        material.SetFloat("_Dissolve_Val", -0.5f);
    }
}
