using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    spawnPos.z = 0;
        //    SpawnProjectileAtLocation(spawnPos);
        //}
    }

    void SpawnProjectileAtLocation(Vector3 spawnPos)
    {
        Instantiate(bombPrefab, spawnPos, Quaternion.identity);
    }
}
