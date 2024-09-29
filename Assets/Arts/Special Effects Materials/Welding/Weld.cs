using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weld : MonoBehaviour
{
    public GameObject weldPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f)) {
                Instantiate(weldPrefab, hit.point, Quaternion.LookRotation(-hit.normal));
            }
        }
    }
}
