using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase : MonoBehaviour {
    public float CD = 5;
    private float currentCD;

    public GameObject boulderPrefab;

    public int amountPerSpawn = 3;

    // Update is called once per frame
    void Update()
    {
        RunSpawnerCooldown();
    }

    protected void RunSpawnerCooldown()
    {
        currentCD -= Time.deltaTime;

        if (currentCD <= 0)
        {
            Spawn();
            currentCD = CD;
        }
    }

    protected virtual void Spawn()
    {
    }
}
