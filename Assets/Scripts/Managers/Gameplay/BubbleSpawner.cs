using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : SpawnerBase {
    private void Update()
    {
        RunSpawnerCooldown();
    }

    protected override void Spawn()
    {
        GameObject spawnedObject = GameObject.Instantiate(boulderPrefab, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Rigidbody>().velocity = Vector3.up * 1;      
    }
}
