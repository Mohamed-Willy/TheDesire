using UnityEngine;

public class IonizerHole : MonoBehaviour
{
    [SerializeField] GameObject Placer;
    int asteroidCount = 6;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            asteroidCount--;
            Destroy(other.gameObject);
            if (asteroidCount == 0)
            {
                Placer.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
