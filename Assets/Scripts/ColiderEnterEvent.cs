using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColiderEnterEvent : MonoBehaviour
{
    [SerializeField] string objTag;
    [SerializeField] UnityEvent onCol;
    [SerializeField] UnityEvent onTrig;
    private void OnCollisionEnter(Collision collision)
    {
        onCol.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        onTrig.Invoke();
    }
}
