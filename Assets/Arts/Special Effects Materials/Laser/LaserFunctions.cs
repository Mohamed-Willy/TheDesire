using UnityEngine;

public class LaserFunctions : MonoBehaviour
{
    public static LaserFunctions Instance { get; private set; }
    LineRenderer lineRenderer;

    void Awake () {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void UpdateLaserColor (Color color) {
        lineRenderer.material.SetColor("_BaseColor", color);
    }
}
