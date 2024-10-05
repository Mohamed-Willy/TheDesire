using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    [SerializeField] RoomOneManger manger;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] Material newMaterial;
    [SerializeField] UnityEvent<float> OnDissolveShapes;
    [SerializeField] VisualEffect vfx;
    [SerializeField] float duration = 10;
    Transform m_Transform;
    Rigidbody m_Rigidbody;
    bool isMoving;
    private void Start()
    {
        
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

        vfx?.SetFloat("Duration", duration/1.25f);
        vfx?.Play();

        AudioManager.Instance.playSFX(AudioManager.Instance.disintegrationSound);

        OnDissolveShapes?.Invoke(duration);

        yield return new WaitForSeconds(duration);
        
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
