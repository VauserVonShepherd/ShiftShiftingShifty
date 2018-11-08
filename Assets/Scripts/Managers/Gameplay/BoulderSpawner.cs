
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : SpawnerBase {

    private void Update()
    {
        RunSpawnerCooldown();
    }

    protected override void Spawn()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            GameObject spawnedObject = GameObject.Instantiate(boulderPrefab, transform.position + Vector3.up * i * 2, Quaternion.identity);
        }
    }
}
