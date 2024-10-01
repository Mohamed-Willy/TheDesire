using UnityEngine;

public class Cannon : MonoBehaviour
{
    public static bool canShoot = true;
    [SerializeField] GameObject Projectile;
    public void shoot()
    {
        if (!canShoot) return;
        canShoot = false;
        GameObject obj = Instantiate(Projectile);
        obj.transform.parent = Projectile.transform.parent;
        obj.transform.SetPositionAndRotation(Projectile.transform.position, Projectile.transform.rotation);
        obj.SetActive(true);
    }
}
