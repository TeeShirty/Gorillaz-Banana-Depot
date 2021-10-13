using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public GameObject projectilePrefab;

    public Transform projectileSpawnpoint;

    public void Shoot(int power)
    {
        GameObject instantiateProjectile =
            Instantiate(projectilePrefab, projectileSpawnpoint.transform.position, projectileSpawnpoint.transform.rotation);

        instantiateProjectile.GetComponent<Projectile>().Initialize(power);
    }
}
