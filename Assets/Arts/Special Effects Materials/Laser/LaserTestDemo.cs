using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LaserFunctions.Instance.UpdateLaserColor(Random.ColorHSV(0.0f, 1.0f, 0.5f, 1.0f, 0.95f, 1.0f));
    }
}
